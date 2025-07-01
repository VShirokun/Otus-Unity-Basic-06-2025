using Game.Engine;
using UnityEngine;

namespace Game.App
{
    public sealed class CharacterAnalyticsTracker : MonoBehaviour
    {
        private ICharacterService characterService;

        private void Awake()
        {
            this.characterService = ServiceLocator.GetService<ICharacterService>();
        }

        private void OnEnable()
        {
            GameObject character = this.characterService.Character;
            character.GetComponent<PickUpComponent>().OnPickedUp += AnalyticsEvents.LogPickUpItem;
            character.GetComponent<LifeComponent>().OnDeath += AnalyticsEvents.LogCharacterDeath;
        }
        
        private void OnDisable()
        {
            GameObject character = this.characterService.Character;
            character.GetComponent<PickUpComponent>().OnPickedUp -= AnalyticsEvents.LogPickUpItem;
            character.GetComponent<LifeComponent>().OnDeath -= AnalyticsEvents.LogCharacterDeath;
        }
    }
}