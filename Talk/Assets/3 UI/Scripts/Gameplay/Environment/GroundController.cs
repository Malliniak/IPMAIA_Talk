using UI.Gameplay.Player;
using UnityEngine;

namespace UI.Gameplay.Environment
{
    public class GroundController : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D other)
        {
            if(other.gameObject.GetComponent<PlayerController>())
                other.gameObject.GetComponent<PlayerController>().PlayerDeath();
        }
    }
}
