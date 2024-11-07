using UnityEngine;

public class AidKit : MonoBehaviour
{
    [SerializeField] private int _healAmount = 10;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Player _))
        {
            HealthHandler healthHandler = other.GetComponent<HealthHandler>();

            if (healthHandler != null)
            {
                healthHandler.Heal(_healAmount);

                Destroy(gameObject);

                Debug.Log("CurrentHealth: " + healthHandler.CurrentHealth);
            }
        }
    }
}