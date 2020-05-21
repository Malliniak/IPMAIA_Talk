using UnityEngine;

namespace Basic_no_refactor
{
    public class PlayerController : MonoBehaviour
    {
        private Rigidbody2D _rigidbody2D;
        private SpriteRenderer _spriteRenderer;
        private PointsDisplayController _pointsDisplayController;

        [SerializeField] private float _jumpForce = 15;

        private int _points;

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
            if (other.GetComponent<CoinController>())
            {
                _points += other.GetComponent<CoinController>().Points;
                Debug.Log($"<color=green><b> Collected </b></color>: {other.GetComponent<CoinController>().Points} points");
                Destroy(other.gameObject);
                _pointsDisplayController._text.text = $"{_points}";
            }

            if (other.GetComponent<BombController>())
            {
                _points -= other.GetComponent<BombController>().Points;
                Debug.Log($"<color=red><b> Lost </b></color>: {other.GetComponent<BombController>().Points} points");
                Destroy(other.gameObject);
                _pointsDisplayController._text.text = $"{_points}";
                if(_points <= 0)
                    Destroy(gameObject);
            }
        }

        private void OnDestroy()
        {
            Time.timeScale = 0;
        }
    }
}
