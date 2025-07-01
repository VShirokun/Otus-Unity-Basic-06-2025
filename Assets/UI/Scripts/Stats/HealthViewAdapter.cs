using Game.Engine;
using UnityEngine;

namespace Game.UI
{
    [RequireComponent(typeof(StatView))]
    internal sealed class HealthViewAdapter : MonoBehaviour 
    {
        private StatView healthView;

        private LifeComponent _lifeComponent;

        private void Awake()
        {
            this.healthView = this.GetComponent<StatView>();
            _lifeComponent = ServiceLocator
                .GetService<ICharacterService>()
                .Character.GetComponent<LifeComponent>();
        }

        private void OnEnable()
        {
            _lifeComponent.OnStateChanged += this.OnHealthChanged;
            this.OnHealthChanged();
        }

        private void OnDisable()
        {
            _lifeComponent.OnStateChanged -= this.OnHealthChanged;
        }

        private void OnHealthChanged()
        {
            this.healthView.SetText(_lifeComponent.GetCurrentHitPoints().ToString());
            this.healthView.SetProgress(_lifeComponent.GetHealthPercent());
        }
    }
}