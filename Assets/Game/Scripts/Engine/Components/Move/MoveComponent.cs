using System;
using UnityEngine;

namespace Game.Engine
{
    public sealed class MoveComponent : MonoBehaviour
    {
        [SerializeField]
        private Vector3 currentDirection;

        private readonly AndCondition condition = new();
        
        public Vector3 GetDirection()
        {
            return this.currentDirection;
        }
        
        public void SetDirection(Vector3 moveDirection)
        {
            this.currentDirection = moveDirection;
        }

        public void AddCondition(Func<bool> condition)
        {
            this.condition.Add(condition);
        }

        public void RemoveCondition(Func<bool> condition)
        {
            this.condition.Remove(condition);
        }
        
        public bool CanMove()
        {
            return this.condition.IsTrue();
        }

        public bool IsNotMoving()
        {
            return !this.IsMoving();
        }

        public bool IsMoving()
        {
            return this.currentDirection.sqrMagnitude > 0 && this.CanMove();
        }
    }
}