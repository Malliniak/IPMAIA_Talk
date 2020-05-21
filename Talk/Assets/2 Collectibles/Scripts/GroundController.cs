using UnityEngine;

namespace Collectibles
{
    public class GroundController : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D other)
        {
            if(other.gameObject.GetComponent<PlayerController>())
                Destroy(other.gameObject);
        }
    }
}
