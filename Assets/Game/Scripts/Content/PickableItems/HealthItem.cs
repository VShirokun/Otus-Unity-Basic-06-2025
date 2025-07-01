using Game.Engine;
using UnityEngine;

namespace Game.Content
{
    public sealed class HealthItem : PickableItemBase
    {
        [SerializeField, Space]
        private int healingPoints = 3;

        public override string Id => this.name;

        protected override bool ProcessPickUp(GameObject target)
        {
            if (target.TryGetComponent(out LifeComponent lifeComponent) &&
                !lifeComponent.IsHealthFull())
            {
                lifeComponent.RestoreHitPoints(this.healingPoints);
                return true;
            }

            return false;
        }
    }
}