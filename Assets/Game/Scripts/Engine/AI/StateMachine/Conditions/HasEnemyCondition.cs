using System;
using UnityEngine;

namespace Game.Engine
{
    [Serializable]
    public sealed class HasEnemyCondition : IStateCondition
    {
        [SerializeField]
        private TargetComponent targetComponent;
        
        public bool IsTrue()
        {
            if (!this.targetComponent.TryGetTarget(out GameObject target))
            {
                return false;
            }

            if (!target.TryGetComponent(out LifeComponent lifeComponent))
            {
                return false;
            }

            return lifeComponent.IsAlive();
        }
    }
}