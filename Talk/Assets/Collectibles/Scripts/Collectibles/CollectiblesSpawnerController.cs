﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Collectibles.Collectibles
{
    public class CollectiblesSpawnerController : MonoBehaviour
    {
        public List<BaseCollectible> _collectibles = new List<BaseCollectible>();

        public float _rateOfSpawn;

        private void Start()
        {
            StartCoroutine(nameof(PickupSpawn));
        }

        private IEnumerator PickupSpawn()
        {
            while (true)
            {
                int newInt = Random.Range(0, _collectibles.Count-1);
                BaseCollectible newCollectible = _collectibles[newInt];
                Instantiate(newCollectible, new Vector3(Random.Range(-9, 9), transform.position.y), Quaternion.identity);
                yield return new WaitForSeconds(_rateOfSpawn);
            }
        }
    }
}