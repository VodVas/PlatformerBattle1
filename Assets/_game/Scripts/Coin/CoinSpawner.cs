using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _coinPrefab;
    [SerializeField] private float _respawnDelay = 5f;
    [SerializeField] private List<Transform> _coinTransforms;

    private ObjectPool<Coin> _coinPool;
    private List<Vector2> _coinPositions = new List<Vector2>();

    private void Start()
    {
        _coinPool = new ObjectPool<Coin>(CreateCoin, OnGetFromPool, OnReleaseToPool, OnDestroyPoolObject, true);
        InitCoins();
    }

    private void OnDisable()
    {
        _coinPool.Clear();
    }

    private void InitCoins()
    {
        foreach (var transform in _coinTransforms)
        {
            _coinPositions.Add(transform.position);
        }

        for (int i = 0; i < _coinPositions.Count; i++)
        {
            SpawnCoin(i);
        }
    }

    private Coin CreateCoin()
    {
        Coin coin = Instantiate(_coinPrefab);

        return coin;
    }

    private void OnGetFromPool(Coin coin)
    {
        coin.OnCoinCollected += CollectCoin;
        coin.gameObject.SetActive(true);
    }

    private void OnReleaseToPool(Coin coin)
    {
        coin.OnCoinCollected -= CollectCoin;
        coin.gameObject.SetActive(false);
    }

    private void OnDestroyPoolObject(Coin coin)
    {
        if (coin != null)
        {
            Destroy(coin.gameObject);
        }
    }

    public void CollectCoin(Coin coin)
    {
        int InvalidIndex = -1;
        int index = _coinPositions.IndexOf(coin.transform.position);

        if (index != InvalidIndex)
        {
            _coinPool.Release(coin);

            StartCoroutine(RespawnCoinAfterDelay(index));
        }
    }

    private IEnumerator RespawnCoinAfterDelay(int index)
    {
        yield return new WaitForSeconds(_respawnDelay);

        SpawnCoin(index);
    }

    private void SpawnCoin(int index)
    {
        if (index >= 0 && index < _coinPositions.Count)
        {
            Coin coin = _coinPool.Get();
            coin.transform.position = _coinPositions[index];
        }
    }
}