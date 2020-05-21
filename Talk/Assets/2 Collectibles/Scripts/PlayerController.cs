using Collectibles.Collectibles;
using UnityEngine;

namespace Collectibles
{
    public class PlayerController : MonoBehaviour
    {
        private Rigidbody2D _rigidbody2D;
        private SpriteRenderer _spriteRenderer;
        public PointsDisplayController _pointsDisplayController;

        [SerializeField] private float _jumpForce = 15;

        public int Points { get; set; }

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _pointsDisplayController = FindObjectOfType<PointsDisplayController>();
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
            if (other.GetComponent<IPlayerCollectible>() != null)
            {
                other.GetComponent<IPlayerCollectible>().OnPlayerCollect(this);
                _pointsDisplayController._text.text = $"{Points}";
                if(Points <= 0)
                    Destroy(gameObject);
            }
        }

        private void OnDestroy()
        {
            Time.timeScale = 0;
        }
    }
}
