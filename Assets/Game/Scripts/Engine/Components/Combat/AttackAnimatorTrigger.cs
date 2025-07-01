using UnityEngine;

namespace Game.Engine
{
    [RequireComponent(typeof(Animator))]
    public sealed class AttackAnimatorTrigger : MonoBehaviour
    {
        private static readonly int Attack = Animator.StringToHash("Attack");

        private Animator animator;

        [SerializeField]
        private AttackComponent attackComponent;

        private void Awake()
        {
            this.animator = this.GetComponent<Animator>();
        }

        private void FixedUpdate()
        {
            if (this.attackComponent.IsAttacking())
            {
                this.animator.SetTrigger(Attack);
            }
        }
    }
}