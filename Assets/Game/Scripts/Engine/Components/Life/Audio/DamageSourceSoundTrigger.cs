using UnityEngine;

namespace Game.Engine
{
    [RequireComponent(typeof(AudioSource))]
    internal sealed class DamageSourceSoundTrigger : MonoBehaviour
    {
        [SerializeField]
        private LifeComponent lifeComponent;

        [SerializeField, Space]
        private AudioClip meleeSFX;

        [SerializeField]
        private AudioClip bulletSFX;

        private AudioSource audioSource;

        private void Awake()
        {
            this.audioSource = this.GetComponent<AudioSource>();
        }

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

            if (source.CompareTag(Tags.Melee))
            {
                this.audioSource.PlayOneShot(this.meleeSFX);
            }
            else if (source.CompareTag(Tags.Bullet))
            {
                this.audioSource.PlayOneShot(this.bulletSFX);
            }
        }
    }
}