using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Engine
{
    public sealed class GameManager : MonoBehaviour
    {
        public event Action OnGameStarted;
        public event Action OnGamePaused;
        public event Action OnGameResumed;
        public event Action OnGameFinished;

        [SerializeField]
        private bool playOnStart = true;

        public void Start()
        {
            if (this.playOnStart)
            {
                this.Play();
            }
        }

        [Button]
        public void Play()
        {
            Time.timeScale = 1;
            this.OnGameStarted?.Invoke();
        }

        [Button]
        public void Pause()
        {
            Time.timeScale = 0;
            this.OnGamePaused?.Invoke();
        }

        [Button]
        public void Resume()
        {
            Time.timeScale = 1;
            this.OnGameResumed?.Invoke();
        }

        [Button]
        public void Finish()
        {
            Time.timeScale = 0;
            this.OnGameFinished?.Invoke();
        }

        [ContextMenu("ResetGame")]
        public void ResetGame()
        {
            Debug.Log("Reset game");
        }

        [Button]
        public void LoadGame(int level)
        {
            Debug.Log($"Load level {level}");
        }
    }
}