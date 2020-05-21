using System;
using Final.Core;
using Final.Gameplay.Collectibles;
using UnityEngine;

namespace Final.Gameplay.Player
{
    public class PlayerController : MonoBehaviour
    {
        private Rigidbody2D _rigidbody2D;
        private SpriteRenderer _spriteRenderer;
        private GameController _gameController;

        [SerializeField] private float _jumpForce = 15;

        public event Action<int> PlayerScoreUpdated;
        public event Action PlayerDied;

        public int Points { get; set; }

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _gameController = FindObjectOfType<GameController>();
        }

        private void Start()
        {
            PlayerScoreUpdated += _gameController.OnPlayerScoreUpdated;
            PlayerDied += _gameController.StopGame;
        }

        private void Update()
        {
            if (Input.anyKeyDown)
            {
                PlayerMove(Input.GetAxisRaw("Horizontal"));
            }
        }

        private void PlayerMove(float axisRaw)
        {
            _spriteRenderer.flipX = axisRaw > 0;
            _rigidbody2D.AddForce(new Vector2(0.5f * axisRaw, 0.5f) * _jumpForce, ForceMode2D.Impulse);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            IPlayerCollectible playerCollectible = other.GetComponent<IPlayerCollectible>();
            
            if (playerCollectible == null) 
                return;
            
            playerCollectible.OnPlayerCollect(this);
            PlayerScoreUpdated?.Invoke(Points);
            if (Points <= 0)
                PlayerDeath();
        }

        public void PlayerDeath()
        {
            PlayerDied?.Invoke();
            Destroy(gameObject);
        }

        private void OnDestroy()
        {
            // Good practice to unsubscribe
            PlayerScoreUpdated -= _gameController.OnPlayerScoreUpdated;
            PlayerDied -= _gameController.StopGame;
        }
    }
}
