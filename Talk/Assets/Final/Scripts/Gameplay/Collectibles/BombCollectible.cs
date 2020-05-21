using Final.Gameplay.Player;
using UnityEngine;

namespace Final.Gameplay.Collectibles
{
    internal class BombCollectible : BaseCollectible
    {
        public override void OnPlayerCollect(PlayerController playerController)
        {
            playerController.Points -= _points;
            Debug.Log($"<color=red><b> Lost </b></color>: {_points} points", playerController);
            Destroy(gameObject);
        }
    }
}
