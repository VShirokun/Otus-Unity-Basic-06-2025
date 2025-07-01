using System;
using UnityEngine;

namespace Game.Engine
{
    public sealed class JoystickInput : MonoBehaviour
    {
        private const float FIRE_DELAY = 0.5f;
        private const float MELEE_DELAY = 0.1f;

        [SerializeField]
        private MoveJoystick moveJoystick;

        [SerializeField]
        private AttackJoystick attackJoystick;

        [SerializeField]
        private bool controlMove = true;

        [SerializeField]
        private bool controlFire = true;

        [SerializeField]
        private bool controlAim = true;

        private float fireTime;

        private CharacterService character;

        private void Awake()
        {
            this.character = ServiceLocator.GetService<CharacterService>();
        }

        private void OnEnable()
        {
            this.attackJoystick.OnFireStarted += this.OnFireStarted;
        }
        
#if !UNITY_EDITOR
        private void Start()
        {
            this.controlMove = true;
            this.controlFire = true;
            this.controlAim = true;
        }
#endif
        
        private void OnDisable()
        {
            this.attackJoystick.OnFireStarted -= this.OnFireStarted;
        }

        private void OnFireStarted()
        {
            //TODO: Сделать правило атаки для каждого оружия отдельно, не в контроллере!
            WeaponComponent weaponComponent = this.character.Character.GetComponent<WeaponComponent>();
            if (weaponComponent.TryGetCurrentWeapon(out Weapon weapon) && weapon.CompareTag(Tags.Range))
            {
                this.fireTime = Time.time;
            }
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

            if (this.controlAim)
            {
                this.UpdateAim();
            }
        }

        private void UpdateFire()
        {
            if (this.attackJoystick.IsFire)
            {
                var delayFinished = Time.time - this.fireTime >= FIRE_DELAY;
                this.character.SetAttackRequired(delayFinished);
            }
            else
            {
                this.character.SetAttackRequired(false);
            }
        }

        private void UpdateMove()
        {
            Vector2 joystickDirection = this.moveJoystick.Direction;
            Vector3 moveDirection = new Vector3(joystickDirection.x, 0, joystickDirection.y);
            this.character.SetMoveDirection(moveDirection);
        }

        private void UpdateAim()
        {
            Vector2 joystickDirection = this.attackJoystick.Direction;
            Vector3 attackDirection = new Vector3(joystickDirection.x, 0, joystickDirection.y);
            this.character.SetAimDirection(attackDirection);
        }
    }
}