using Game.Engine;
using UnityEngine;

namespace Game.App
{
    public sealed class GameFlowAnalyticsTracker : MonoBehaviour
    {
        private GameManager gameManager;
        
        private void Awake()
        {
            this.gameManager = ServiceLocator.GetService<GameManager>();
        }

        private void OnEnable()
        {
            this.gameManager.OnGameStarted += AnalyticsEvents.LogGameStarted;
            this.gameManager.OnGamePaused += AnalyticsEvents.LogGamePaused;
            this.gameManager.OnGameResumed += AnalyticsEvents.LogGameResumed;
            this.gameManager.OnGameFinished += AnalyticsEvents.LogGameFinished;
        }
        
        private void OnDisable()
        {
            this.gameManager.OnGameStarted -= AnalyticsEvents.LogGameStarted;
            this.gameManager.OnGamePaused -= AnalyticsEvents.LogGamePaused;
            this.gameManager.OnGameResumed -= AnalyticsEvents.LogGameResumed;
            this.gameManager.OnGameFinished -= AnalyticsEvents.LogGameFinished;
        }
    }
}