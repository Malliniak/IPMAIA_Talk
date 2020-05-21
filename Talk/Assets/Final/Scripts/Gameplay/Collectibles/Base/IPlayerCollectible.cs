using Final.Gameplay.Player;

namespace Final.Gameplay.Collectibles
{
    public interface IPlayerCollectible
    {
        void OnPlayerCollect(PlayerController playerController);
    }
}