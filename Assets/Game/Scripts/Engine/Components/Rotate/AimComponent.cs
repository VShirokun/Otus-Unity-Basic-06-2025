using System;
using UnityEngine;

namespace Game.Engine
{
    public sealed class AimComponent : MonoBehaviour
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
        
        public bool CanRotate()
        {
            return this.condition.IsTrue();
        }

        public bool IsRotating()
        {
            return this.currentDirection.sqrMagnitude > 0 && this.CanRotate();
        }
    }
}