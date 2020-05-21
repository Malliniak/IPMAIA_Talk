using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using Random = System.Random;

public class CoinController : MonoBehaviour
{
    [SerializeField] private int _points = 0;
    public int Points => _points;

    private void Start()
    {
        Random newRandom = new Random();
        _points = newRandom.Next(1, 10);
    }
}
