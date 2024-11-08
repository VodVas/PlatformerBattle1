using UnityEngine;

public class AidKit : CollectibleItem
{
    [SerializeField] private int _healAmount = 10;
    [SerializeField] private Health _health;

    public override void Collect()
    {
        if (_health != null)
        {
            _health.Increase(_healAmount);
        }

        Destroy(gameObject);
    }
}