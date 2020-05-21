using System;
using UI.Core;
using UI.Gameplay.Collectibles;
using UnityEngine;

namespace UI.Gameplay.Player
{
    public class PlayerController : MonoBehaviour
    {
        private Rigidbody2D _rigidbody2D;
        private SpriteRenderer _spriteRenderer;
        public GameController _gameController;

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
            if (Input.GetKeyDown(KeyCode.A))
            {
                _spriteRenderer.flipX = false;
                _rigidbody2D.AddForce(new Vector2(-0.5f, 0.5f) * _jumpForce, ForceMode2D.Impulse);
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                _spriteRenderer.flipX = true;
                _rigidbody2D.AddForce(new Vector2(0.5f, 0.5f) * _jumpForce, ForceMode2D.Impulse);
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.GetComponent<IPlayerCollectible>() == null) 
                return;
            
            other.GetComponent<IPlayerCollectible>().OnPlayerCollect(this);
            PlayerScoreUpdated?.Invoke(Points);
            if (Points <= 0)
                PlayerDeath();
        }

        public void PlayerDeath()
        {
            PlayerDied?.Invoke();
            Destroy(gameObject);
        }
    }
}
