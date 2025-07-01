using UnityEngine;

namespace Game.Engine
{
    internal sealed class CharacterService : MonoBehaviour, ICharacterService
    {
        [field: SerializeField]
        public GameObject Character { get; private set; }
        
        private MoveComponent _moveComponent;
        private AimComponent _aimComponent;
        private AttackComponent _attackComponent;

        private void Awake()
        {
            _moveComponent = this.Character.GetComponent<MoveComponent>();
            _aimComponent = this.Character.GetComponent<AimComponent>();
            _attackComponent = this.Character.GetComponent<AttackComponent>();
        }

        public void SetMoveDirection(Vector3 direction)
        {
            _moveComponent.SetDirection(direction);
        }

        public void SetAimDirection(Vector3 direction)
        {
            _aimComponent.SetDirection(direction);
        }

        public void SetAttackRequired(bool attackRequired)
        {
            _attackComponent.SetRequired(attackRequired);
        }
    }
}