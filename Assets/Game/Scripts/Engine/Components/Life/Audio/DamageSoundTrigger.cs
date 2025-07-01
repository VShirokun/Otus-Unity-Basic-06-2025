using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game.Engine
{
    public sealed class DamageSoundTrigger : MonoBehaviour
    {
        [SerializeField]
        private LifeComponent lifeComponent;

        private AudioSource audioSource;

        [SerializeField]
        private AudioClip[] audioClips;

        private readonly List<AudioClip> availableClips = new();

        private void Awake()
        {
            this.audioSource = this.GetComponent<AudioSource>();
        }

        private void OnEnable()
        {
            this.lifeComponent.OnDamageTaken += this.OnDamageTaken;
        }

        private void OnDisable()
        {
            this.lifeComponent.OnDamageTaken -= this.OnDamageTaken;
        }

        private void OnDamageTaken(GameObject source, int damage)
        {
            if (this.availableClips.Count == 0)
            {
                this.availableClips.AddRange(this.audioClips);
            }

            int randomIndex = Random.Range(0, availableClips.Count);
            AudioClip targetClip = this.availableClips[randomIndex];
            this.availableClips.Remove(targetClip);
            
            this.audioSource.PlayOneShot(targetClip);
            
        }
    }
}