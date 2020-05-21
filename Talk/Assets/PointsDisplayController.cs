using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsDisplayController : MonoBehaviour
{
    public Text _text;

    private void Awake()
    {
        _text = GetComponent<Text>();
    }
}
