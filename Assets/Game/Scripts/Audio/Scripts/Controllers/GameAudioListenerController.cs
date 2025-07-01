using System;
using UnityEngine;

namespace Game.Engine.Audio
{
    public sealed class GameAudioListenerController : MonoBehaviour
    {
        private GameManager gameManager;

        private void Awake()
        {
            this.gameManager = ServiceLocator.GetService<GameManager>();
        }

        private void OnEnable()
        {
            this.gameManager.OnGamePaused += OnGamePaused;
            this.gameManager.OnGameResumed += OnGameResumed;
            this.gameManager.OnGameFinished += OnGameFinished;
        }

        private void OnDisable()
        {
            this.gameManager.OnGamePaused -= OnGamePaused;
            this.gameManager.OnGameResumed -= OnGameResumed;
            this.gameManager.OnGameFinished -= OnGameFinished;
        }

        private void OnGameResumed()
        {
            AudioListener.pause = false;
        }

        private void OnGamePaused()
        {
            AudioListener.pause = true;
        }

        private void OnGameFinished()
        {
            AudioListener.pause = true;
        }
    }
}