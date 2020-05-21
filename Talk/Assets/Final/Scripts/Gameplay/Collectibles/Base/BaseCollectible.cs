using Final.Gameplay.Player;
using UnityEngine;

namespace Final.Gameplay.Collectibles
{
    /*
     * Base Collectible - that allows us to use and serialize it inside the inspector.
     * Controls mutual initialization - rigidbody and gravity scale.
     */
    public class BaseCollectible : MonoBehaviour, IPlayerCollectible
    {
        [SerializeField] internal int _points = 0; // Internal field in order to use it inside children
        private Rigidbody2D _rigidbody2D;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            _points = Random.Range(1, 10);
            _rigidbody2D.gravityScale = Random.Range(0.3f, 0.7f);
            Destroy(gameObject, 5f);
        }
        
        public virtual void OnPlayerCollect(PlayerController playerController)
        {
            Debug.Log("<color=red><b>I am a base collectible, I do not do anything :( </b></color>", playerController);
        }
    }
}