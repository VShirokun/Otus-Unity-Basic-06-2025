using UnityEngine;

namespace Game.Engine
{
    public sealed class PauseGameAction : MonoBehaviour
    {
        public void PauseGame()
        {
            ServiceLocator.GetService<GameManager>().Pause();
        }
    }
}