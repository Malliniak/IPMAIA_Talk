using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class BombController : MonoBehaviour
{
    [SerializeField] private int _pointsToDecrease = 0;
    public int Points => _pointsToDecrease;

    private void Start()
    {
        Random random = new Random();
        _pointsToDecrease = random.Next(1, 10);
    }
}
