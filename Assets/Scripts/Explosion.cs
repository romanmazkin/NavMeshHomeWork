using UnityEngine;

public class Explosion
{
    private float _explosionRadius;
    private float _damageValue;
    private Health _targetHealth;

    public Explosion(float explosionRadius, float damageValue)
    {
        _explosionRadius = explosionRadius;
        _damageValue = damageValue;
    }

    public void MakeExplosionIn(Vector3 explosionPoint, Health targetHealth)
    {
        targetHealth.TakeDamage(_damageValue);
    }
}
