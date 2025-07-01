using UnityEngine;

namespace Game.Engine
{
    [RequireComponent(typeof(Animator))]
    public sealed class DeathAnimatorTrigger : MonoBehaviour
    {
        private static readonly int DeathTrigger = Animator.StringToHash("Death");

        [SerializeField]
        private LifeComponent lifeComponent;
        
        private Animator animator;
        
        private void Awake()
        {
            this.animator = this.GetComponent<Animator>();
        }

        private void OnEnable()
        {
            this.lifeComponent.OnDeath += this.OnDeath;
        }

        private void OnDisable()
        {
            this.lifeComponent.OnDeath -= this.OnDeath;
        }

        private void OnDeath(GameObject source, int damage)
        {
            this.animator.SetTrigger(DeathTrigger);
        }
    }
}