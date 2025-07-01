using Game.Engine;
using UnityEngine;

namespace Game.Content
{
    public sealed class Character : MonoBehaviour
    {
        [SerializeField]
        private LifeComponent lifeComponent;

        [SerializeField]
        private MoveComponent moveComponent;

        [SerializeField]
        private AimComponent aimComponent;

        [SerializeField]
        private AttackComponent attackComponent;

        [SerializeField]
        private WeaponComponent weaponComponent;

        [SerializeField]
        private SmoothRotateAction rotateAction;

        [SerializeField]
        private float moveRotationSpeed = 12;

        [SerializeField]
        private float aimRotationSpeed = 6;

        [SerializeField]
        private new Collider collider;

        private void Awake()
        {
            this.moveComponent
                .AddCondition(this.lifeComponent.IsAlive);

            this.aimComponent
                .AddCondition(lifeComponent.IsAlive);

            this.attackComponent
                .AddCondition(this.lifeComponent.IsAlive)
                .AddCondition(() => !this.weaponComponent.HasWeapon() || this.weaponComponent.CanFire());
        }

        private void OnEnable()
        {
            this.lifeComponent.OnDeath += this.OnDeath;
        }

        private void OnDisable()
        {
            this.lifeComponent.OnDeath -= this.OnDeath;
        }

        private void Start()
        {
            this.collider.enabled = true;
        }


        private void FixedUpdate()
        {
            var deltaTime = Time.fixedDeltaTime;

            if (this.aimComponent.IsRotating())
            {
                this.rotateAction.RotateTowards(this.aimComponent.GetDirection(), Vector3.up, deltaTime, this.aimRotationSpeed);
            }
            else if (this.moveComponent.IsMoving())
            {
                this.rotateAction.RotateTowards(this.moveComponent.GetDirection(), Vector3.up, deltaTime, this.moveRotationSpeed);
            }
        }

        private void OnDeath(GameObject source, int damage)
        {
            this.collider.enabled = false;
        }
    }
}