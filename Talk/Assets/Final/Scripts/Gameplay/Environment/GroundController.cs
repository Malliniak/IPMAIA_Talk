using Final.Gameplay.Player;
using UnityEngine;

namespace Final.Gameplay.Environment
{
    public class GroundController : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D other)
        {
            PlayerController playerController = other.gameObject.GetComponent<PlayerController>();
            
            if (playerController == null) 
                return;
                
            playerController.PlayerDeath();
        }
    }
}
