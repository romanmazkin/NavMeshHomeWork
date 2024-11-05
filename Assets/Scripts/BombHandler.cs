using System.Collections;
using UnityEngine;

public class BombHandler : MonoBehaviour
{
    [SerializeField] private ParticleSystem _explosionParticle;
    [SerializeField] private float _explosionRadius = 5f;
    [SerializeField] private float _explosionTime = 2f;
    [SerializeField] private float _damageValue = 30f;

    private bool _isExploded = false;
    private CharacterView _view;
    private Health _targetHealth;
    private Explosion _explosion;

    private void Awake()
    {
        _explosion = new Explosion(_explosionRadius, _damageValue);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (IsCharacter(other))
        {
            StartCoroutine(Explode(other, _explosionTime));
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (_isExploded == true && IsCharacter(other))
        {
            DealDamageTo(other);
        }
    }

    private bool IsCharacter(Collider other)
    {
        return other.TryGetComponent<Health>(out _targetHealth);
    }

    private void DealDamageTo(Collider other)
    {
        _explosion.MakeExplosionIn(transform.position, _targetHealth);

        other.GetComponentInChildren<CharacterView>().SetHitAnimation();
    }

    private IEnumerator Explode(Collider other, float explosionTime)
    {
        yield return new WaitForSecondsRealtime(explosionTime);

        _isExploded = true;

        Instantiate(_explosionParticle, transform.position, Quaternion.identity);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _explosionRadius);
    }
}
