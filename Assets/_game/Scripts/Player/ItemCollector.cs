using System;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    public event Action<Coin> CoinCollect;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out CollectibleItem item))
        {
            if (item is Coin coin && !coin.IsCollected)
            {
                CoinCollect?.Invoke(coin);

                coin.Collect();
            }
            else if (item is AidKit aidKit)
            {
                aidKit.Collect();
            }
        }
    }
}