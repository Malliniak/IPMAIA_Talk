using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class PickupSpawnerController : MonoBehaviour
{
    public BombController _bombControllerPrefab;
    public CoinController _coinControllerPrefab;

    public float _rateOfSpawn;

    private void Start()
    {
        StartCoroutine(nameof(PickupSpawn));
    }

    private IEnumerator PickupSpawn()
    {
        while (true)
        {
            int newInt = Random.Range(0, 10);
            switch (newInt%2)
            {
                case 0:
                    BombController bomb;
                    if (!_bombControllerPrefab) break;
                    bomb = Instantiate(_bombControllerPrefab, new Vector3(Random.Range(-9, 9), transform.position.y, 0),
                        Quaternion.identity);
                    bomb.GetComponent<Rigidbody2D>().gravityScale = Random.Range(0.3f, 1.5f);
                    Destroy(bomb.gameObject, 5f);
                    break;
                default:
                    CoinController coin;
                    if (!_coinControllerPrefab) break;
                    coin = Instantiate(_coinControllerPrefab, new Vector3(Random.Range(-9, 9), transform.position.y, 0),
                        Quaternion.identity);
                    coin.GetComponent<Rigidbody2D>().gravityScale = Random.Range(0.3f, 0.8f);
                    Destroy(coin.gameObject, 5f);
                    break;
            }
            yield return new WaitForSeconds(_rateOfSpawn);
        }
    }
}
