using UnityEngine;

namespace Collectibles.Collectibles
{
    internal class CoinCollectible : BaseCollectible
    {
        public override void OnPlayerCollect(PlayerController playerController)
        {
            playerController.Points += _points;
            Debug.Log($"<color=green><b> Collected </b></color>: {_points} points", playerController);
            Destroy(gameObject);
        }
    }
}
