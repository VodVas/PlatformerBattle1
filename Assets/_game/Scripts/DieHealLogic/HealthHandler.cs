using UnityEngine;

public class HealthHandler : MonoBehaviour
{
    [field: SerializeField] public int MaxHealth { get; private set; } = 100;

    public int CurrentHealth { get; set; }

    private void Start()
    {
        CurrentHealth = MaxHealth;
    }

    private void Update()
    {
        Debug.Log($"{gameObject.name} CurrentHealth " + CurrentHealth);
    }

    public void Heal(int healAmount)
    {
        CurrentHealth = Mathf.Min(CurrentHealth + healAmount, MaxHealth);
    }
}