using UnityEngine;

namespace Game.Engine
{
    public sealed class ResumeGameAction : MonoBehaviour
    {
        public void ResumeGame()
        {
            ServiceLocator.GetService<GameManager>().Resume();
        }
    }
}