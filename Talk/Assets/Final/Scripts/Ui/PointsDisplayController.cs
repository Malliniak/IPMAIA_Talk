using Final.Core;
using UnityEngine;
using UnityEngine.UI;

namespace Final.Ui
{
    public class PointsDisplayController : MonoBehaviour
    {
        private Text _text;
        private GameController _controller;

        private void Awake()
        {
            _controller = FindObjectOfType<GameController>();
            _text = GetComponent<Text>();
        }

        private void Start()
        {
            _controller.PlayerPointsUpdated += UpdateText;
        }

        private void UpdateText(string value)
        {
            _text.text = value;
        }
    }
}
