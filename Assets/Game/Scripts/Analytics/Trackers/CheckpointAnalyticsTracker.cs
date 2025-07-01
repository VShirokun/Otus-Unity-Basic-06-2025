using Game.Engine;
using UnityEngine;

namespace Game.App
{
    public sealed class CheckpointAnalyticsTracker : MonoBehaviour
    {
        private ICharacterService characterService;

        private void Awake()
        {
            this.characterService = ServiceLocator.GetService<ICharacterService>();
        }

        private void OnEnable()
        {
            GameObject character = this.characterService.Character;
            character.GetComponent<TriggerDispatcher>().OnEntered += this.OnTriggerEntered;
        }

        private void OnDisable()
        {
            GameObject character = this.characterService.Character;
            character.GetComponent<TriggerDispatcher>().OnEntered -= this.OnTriggerEntered;
        }

        private void OnTriggerEntered(Collider collider)
        {
            if (collider.TryGetComponent(out CheckpointMarker checkpoint))
            {
                AnalyticsEvents.LogCheckpointReached(checkpoint.name);
            }
        }
    }
}