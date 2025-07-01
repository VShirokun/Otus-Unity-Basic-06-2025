using System;
using UnityEngine;

namespace Game.Engine
{
    [Serializable]
    public sealed class AttackTargetState : IState
    {
        [SerializeField]
        private GameObject unit;

        [SerializeField]
        private TargetComponent targetComponent;

        [SerializeField]
        private MoveAgent moveAgent;

        [SerializeField]
        private float attackDistance = 1.25f;

        private Transform _myTransform;

        private MoveComponent _myMoveComponent;
        private AimComponent _myRotateComponent;
        private AttackComponent _myAttackComponent;

        public void OnEnter()
        {
            _myTransform = this.unit.GetComponent<TransformComponent>().Transform;
            _myMoveComponent = this.unit.GetComponent<MoveComponent>();
            _myRotateComponent = this.unit.GetComponent<AimComponent>();
            _myAttackComponent = this.unit.GetComponent<AttackComponent>();
            
            this.moveAgent.Play();
        }

        public void OnUpdate(float deltaTime)
        {
            GameObject target = this.targetComponent.GetTarget();
            Transform targetTransform = target.GetComponent<TransformComponent>().Transform;

            Vector3 targetPosition = targetTransform.position;
            Vector3 myPosition = _myTransform.position;

            Vector3 delta = targetPosition - myPosition;
            delta.y = 0;

            if (delta.magnitude > this.attackDistance)
            {
                this.moveAgent.SetDestination(targetPosition);
                
                Vector3 moveDirection = this.moveAgent.GetMoveDirection();
                _myMoveComponent.SetDirection(moveDirection);
                _myRotateComponent.SetDirection(moveDirection);
                _myAttackComponent.SetRequired(false);
            }
            else
            {
                _myAttackComponent.SetRequired(true);
                _myMoveComponent.SetDirection(Vector3.zero);
                _myRotateComponent.SetDirection(delta.normalized);
            }
        }

        public void OnExit()
        {
            _myRotateComponent.SetDirection(Vector3.zero);
            _myMoveComponent.SetDirection(Vector3.zero);
            _myAttackComponent.SetRequired(false);
            
            this.moveAgent.Stop();
        }
    }
}