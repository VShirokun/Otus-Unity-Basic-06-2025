#if UNITY_EDITOR
using UnityEngine;

namespace Game.Engine
{
    public sealed class KeyboardInput : MonoBehaviour
    {
        private CharacterService character;

        [SerializeField]
        private bool controlMove = true;

        [SerializeField]
        private bool controlFire = true;

        private void Awake()
        {
            this.character = ServiceLocator.GetService<CharacterService>();
        }

        private void Update()
        {
            if (this.controlMove)
            {
                this.UpdateMove();
            }

            if (this.controlFire)
            {
                this.UpdateFire();
            }
        }

        private void UpdateMove()
        {
            Vector3 moveDirection = Vector3.zero;

            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
            {
                moveDirection.z = 1;
            }
            else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            {
                moveDirection.z = -1;
            }

            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                moveDirection.x = -1;
            }
            else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                moveDirection.x = 1;
            }

            this.character.SetMoveDirection(moveDirection);
        }

        private void UpdateFire()
        {
            bool attackRequired = Input.GetKey(KeyCode.Space);
            this.character.SetAttackRequired(attackRequired);
        }
    }
}
#endif