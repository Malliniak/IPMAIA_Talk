using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Final.Gameplay.Collectibles
{
    public class CollectiblesSpawnerController : MonoBehaviour
    {
        [SerializeField] private List<BaseCollectible> _collectibles = new List<BaseCollectible>();
        [SerializeField] private float _rateOfSpawn;

        private void Start()
        {
            StartCoroutine(nameof(PickupSpawn));
        }

        private IEnumerator PickupSpawn()
        {
            while (true)
            {
                int newInt = Random.Range(0, 20);
                BaseCollectible newCollectible = _collectibles[newInt%2];
                Instantiate(newCollectible, new Vector3(Random.Range(-9, 9), transform.position.y), Quaternion.identity);
                yield return new WaitForSeconds(_rateOfSpawn);
            }
        }
    }
}
