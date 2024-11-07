using UnityEngine;

public class EnemyAttacker : MonoBehaviour
{
    private const string _isHit = "IsHit";

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponentInParent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Player _))
        {
            StartAttack();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent(out Player _))
        {
            StopAttack();
        }
    }

    private void StartAttack()
    {
        _animator.SetBool(_isHit, true);
    }

    private void StopAttack()
    {
        _animator.SetBool(_isHit, false);
    }
}