﻿using UnityEngine;
using UnityEngine.UI;

namespace Collectibles
{
    public class PointsDisplayController : MonoBehaviour
    {
        public Text _text;

        private void Awake()
        {
            _text = GetComponent<Text>();
        }
    }
}