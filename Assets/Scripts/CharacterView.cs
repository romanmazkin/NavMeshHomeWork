using UnityEngine;
using UnityEngine.AI;

public class CharacterView : MonoBehaviour
{
    private readonly int TakeHitKey = Animator.StringToHash("TakeHit");
    private readonly int IsRunningKey = Animator.StringToHash("IsRunning");
    private readonly int IsDeadKey = Animator.StringToHash("IsDead");

    [SerializeField] private Animator _animator;
    [SerializeField] private NavMeshAgent _agent;

    private void Update()
    {
        if(_agent.isPathStale)
        {
            StartRunning();
        }
        else
        {
            StopRunning();
        }
    }

    public void StartRunning()
    {
        _animator.SetBool(IsRunningKey, true); 
    }

    public void StopRunning()
    {
        _animator.SetBool(IsRunningKey, false);
    }

    public void SetHitAnimation()
    {
        _animator.SetTrigger(TakeHitKey);
    }

    public void DeathAnimation()
    {
        _animator.SetBool(IsDeadKey, true);
    }
}
