using UnityEngine;

[RequireComponent(typeof(DieHandler))]
[RequireComponent(typeof(HealthHandler))]
public class DamageHandler : MonoBehaviour
{
    private HealthHandler _healthHandler;
    private DieHandler _dieHandler;

    private void Awake()
    {
        _healthHandler = GetComponent<HealthHandler>();
        _dieHandler = GetComponent<DieHandler>();
    }

    public void TakeDamage(int damage)
    {
        _healthHandler.CurrentHealth = Mathf.Max(_healthHandler.CurrentHealth - damage, 0);

        if (_healthHandler.CurrentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if (_dieHandler != null)
        {
            _dieHandler.Die();
        }
    }
}