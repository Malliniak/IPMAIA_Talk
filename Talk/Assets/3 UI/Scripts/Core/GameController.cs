using System;
using UI.Gameplay.Player;
using UnityEngine;

namespace UI.Core
{
    public class GameController : MonoBehaviour
    {
        public event Action<string> PlayerPointsUpdated;

        private void Start()
        {
            Time.timeScale = 0;
        }
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
                Time.timeScale = 1;
        }
        
        public void OnPlayerScoreUpdated(int obj)
        {
            PlayerPointsUpdated?.Invoke($"{obj}");
        }

        public void StopGame()
        {
            Time.timeScale = 0;
        }
    }
}
