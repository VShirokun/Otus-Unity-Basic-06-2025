using UnityEngine;

namespace Game.Engine
{
    [RequireComponent(typeof(Animator))]
    public sealed class TakeDamageAnimatorTrigger : MonoBehaviour
    {
        private static readonly int TakeDamageTrigger = Animator.StringToHash("TakeDamage");
        
        [SerializeField]
        private LifeComponent lifeComponent;

        private Animator animator;
        
        private void Awake()
        {
            this.animator = this.GetComponent<Animator>();
        }

        private void OnEnable()
        {
            this.lifeComponent.OnDamageTaken += this.OnTakeDamage;
        }

        private void OnDisable()
        {
            this.lifeComponent.OnDamageTaken -= this.OnTakeDamage;
        }

        private void OnTakeDamage(GameObject source, int damage)
        {
            this.animator.SetTrigger(TakeDamageTrigger);
        }
    }
}