using UnityEngine;

namespace Game.Engine.Audio
{
    public sealed class GameMusicController : MonoBehaviour
    {
        private GameManager gameManager;

        private void Awake()
        {
            this.gameManager = ServiceLocator.GetService<GameManager>();
        }

        private void OnEnable()
        {
            this.gameManager.OnGamePaused += MusicManager.Pause;
            this.gameManager.OnGameResumed += MusicManager.Resume;
            this.gameManager.OnGameFinished += MusicManager.Stop;
        }

        private void OnDisable()
        {
            this.gameManager.OnGamePaused -= MusicManager.Pause;
            this.gameManager.OnGamePaused -= MusicManager.Resume;
            this.gameManager.OnGameFinished -= MusicManager.Stop;
        }
    }
}