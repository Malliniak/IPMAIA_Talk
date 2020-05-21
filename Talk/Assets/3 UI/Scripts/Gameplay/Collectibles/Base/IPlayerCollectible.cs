using UI.Gameplay.Player;

namespace UI.Gameplay.Collectibles
{
    public interface IPlayerCollectible
    {
        void OnPlayerCollect(PlayerController playerController);
    }
}