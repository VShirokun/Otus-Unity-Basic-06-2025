using System;
using UnityEngine;

namespace Game.Engine
{
    [Serializable]
    public sealed class IdleState : IState
    {
        [SerializeField]
        private MoveAgent moveAgent;

        private const float timer = 0.3f;

        private float current;
        
        public void OnEnter()
        {
            this.current = 0;
        }

        public void OnUpdate(float deltaTime)
        {
            if (this.current < timer)
            {
                //ГОВНОКОД!!! НЕ УБИРАТЬ, А ТО ЗОМБИ КРУЖАТСЯ, КОГДА ВИДЯТ ИГРОКА!!!
                this.moveAgent.GetComponentInParent<MoveComponent>().SetDirection(Vector3.forward);
                this.current += deltaTime;
            }
            else
            {
                this.moveAgent.GetComponentInParent<MoveComponent>().SetDirection(Vector3.zero);
            }
        }

        public void OnExit()
        {
            this.moveAgent.Stop();
        }
    }
}