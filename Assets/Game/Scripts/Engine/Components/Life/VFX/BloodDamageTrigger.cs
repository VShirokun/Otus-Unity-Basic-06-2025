using UnityEngine;

namespace Game.Engine
{
    public sealed class BloodDamageTrigger : MonoBehaviour
    {
        [SerializeField]
        private ParticleSystem bulletBlood;

        [SerializeField]
        private ParticleSystem meleeBlood;

        [SerializeField, Space]
        private LifeComponent lifeComponent;

        [SerializeField]
        private Transform originTransform;

        private void OnEnable()
        {
            this.lifeComponent.OnDamageTaken += this.OnDamageTaken;
            this.lifeComponent.OnDeath += this.OnDamageTaken;
        }

        private void OnDisable()
        {
            this.lifeComponent.OnDamageTaken -= this.OnDamageTaken;
            this.lifeComponent.OnDeath -= this.OnDamageTaken;
        }

        private void OnDamageTaken(GameObject source, int damage)
        {
            if (source == null)
            {
                return;
            }

            Vector3 sourcePosition = source.transform.position;
            Vector3 myPosition = this.originTransform.position;
            Vector3 direction = (sourcePosition - myPosition).normalized;
            direction.y = 0;
            
            if (source.CompareTag(Tags.Bullet) && this.bulletBlood != null)
            {
                this.bulletBlood.transform.forward = direction;
                this.bulletBlood.Play(withChildren: true);
            }

            if (source.CompareTag(Tags.Melee) && this.meleeBlood != null)
            {
                this.meleeBlood.Play(withChildren: true);
            }
        }
    }
}