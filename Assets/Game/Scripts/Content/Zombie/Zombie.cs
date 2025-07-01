using Game.Engine;
using UnityEngine;

namespace Game.Content
{
    public sealed class Zombie : MonoBehaviour
    {
        [SerializeField]
        private LifeComponent lifeComponent;

        [SerializeField]
        private MoveComponent moveComponent;

        [SerializeField]
        private AimComponent rotateComponent;

        [SerializeField]
        private AttackComponent attackComponent;

        [SerializeField]
        private SmoothRotateAction rotateAction;
        
        [SerializeField]
        private new Collider collider;

        private void Awake()
        {
            this.moveComponent.AddCondition(this.lifeComponent.IsAlive);
            
            this.attackComponent
                .AddCondition(this.lifeComponent.IsAlive)
                .AddCondition(this.moveComponent.IsNotMoving);
            
            this.rotateComponent.AddCondition(this.lifeComponent.IsAlive);
        }

        private void Start()
        {
            this.collider.enabled = true;
        }

        private void OnEnable()
        {
            this.lifeComponent.OnDeath += this.OnDeath;
        }
        
        private void FixedUpdate()
        {
            if (this.rotateComponent.IsRotating())
            {
                this.rotateAction.RotateTowards(this.rotateComponent.GetDirection(), Vector3.up, Time.fixedDeltaTime);
            }
        }

        private void OnDisable()
        {
            this.lifeComponent.OnDeath -= this.OnDeath;
        }

        private void OnDeath(GameObject source, int damage)
        {
            this.collider.enabled = false;
        }
    }
}
//
// [SerializeField]
// private TransformComponent transformComponent;

// public bool Move(Vector3 nextPosition)
// {
//     Vector3 dir = nextPosition - this.transformComponent.Transform.position;
//     this.moveComponent.SetDirection(dir);
//
//     //
//     // if (dir.magnitude > 0.25f)
//     // {
//     //     this.moveComponent.SetDirection(dir);
//     //     return false;
//     // }
//     //
//     // this.moveComponent.SetDirection(Vector3.zero);
//     return true;
// }
        
// if (this.moveComponent.IsMoving())
// {
//     this.rotateComponent.SetDirection(this.moveComponent.GetDirection());
// }