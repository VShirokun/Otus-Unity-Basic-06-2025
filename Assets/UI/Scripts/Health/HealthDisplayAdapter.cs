using Game.Engine;
using UnityEngine;

namespace Game.UI
{
    [RequireComponent(typeof(HealthDisplay))]
    internal sealed class HealthDisplayAdapter : MonoBehaviour
    {
        private HealthDisplay healthDisplay;

        private LifeComponent _lifeComponent;

        private void Awake()
        {
            this.healthDisplay = this.GetComponent<HealthDisplay>();
            
            _lifeComponent = ServiceLocator
                .GetService<ICharacterService>()
                .Character.GetComponent<LifeComponent>();
        }

        private void OnEnable()
        {
            _lifeComponent.OnStateChanged += this.OnHealthChanged;
            _lifeComponent.OnDamageTaken += this.OnTakeDamage;
        }

        private void OnDisable()
        {
            _lifeComponent.OnStateChanged -= this.OnHealthChanged;
            _lifeComponent.OnDamageTaken -= this.OnTakeDamage;
        }
        
        private void OnTakeDamage(GameObject source, int args)
        {
            this.healthDisplay.TakeDamage(args);
        }

        private void OnHealthChanged()
        {
            this.healthDisplay.ChangePercent(_lifeComponent.GetHealthPercent());
        }
    }
}