using System;
using UnityEngine;

namespace Game.Engine
{
    public sealed class AttackComponent : MonoBehaviour
    {
        public bool AttackRequired => this.required;
        
        [SerializeField]
        private bool required;

        private readonly AndCondition condition = new();
        
        public void SetRequired(bool required)
        {
            this.required = required;
        }

        public AttackComponent AddCondition(Func<bool> condition)
        {
            this.condition.Add(condition);
            return this;
        }

        public void RemoveCondition(Func<bool> condition)
        {
            this.condition.Remove(condition);
        }

        public bool CanAttack()
        {
            return this.condition.IsTrue();
        }

        public bool IsAttacking()
        {
            return this.required && this.condition.IsTrue();
        }
    }
}