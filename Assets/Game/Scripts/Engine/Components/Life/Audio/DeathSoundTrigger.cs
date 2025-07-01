using UnityEngine;

namespace Game.Engine
{
    [RequireComponent(typeof(AudioSource))]
    internal sealed class DeathSoundTrigger : MonoBehaviour
    {
        private AudioSource audioSource;
        
        [SerializeField]
        private LifeComponent lifeComponent;
        
        [SerializeField]
        private AudioClip[] audioClips;

        private void Awake()
        {
            this.audioSource = this.GetComponent<AudioSource>();
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
            if (this.audioClips.Length == 0)
            {
                return;
            }
            
            int randomIndex = Random.Range(0, this.audioClips.Length);
            AudioClip sfx = this.audioClips[randomIndex];
            this.audioSource.PlayOneShot(sfx);
        }
    }
}