using UnityEngine;

namespace Game.Engine
{
    public sealed class MoveAnimatorController : MonoBehaviour
    {
        private static readonly int IsMoving = Animator.StringToHash("IsMoving");

        [SerializeField]
        private MoveComponent moveComponent;

        private Animator animator;

        private void Awake()
        {
            this.animator = this.GetComponent<Animator>();
        }

        private void Update()
        {
            this.animator.SetBool(IsMoving, this.moveComponent.IsMoving());
        }
    }
}