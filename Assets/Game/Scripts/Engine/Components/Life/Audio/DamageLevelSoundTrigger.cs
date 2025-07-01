using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game.Engine
{
    [RequireComponent(typeof(AudioSource))]
    internal sealed class DamageLevelSoundTrigger : MonoBehaviour
    {
        [SerializeField]
        private LifeComponent lifeComponent;

        private AudioSource audioSource;

        [SerializeField]
        private Sound[] audioClips;

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
            float healthPercent = this.lifeComponent.GetHealthPercent();
            this.PlaySound(healthPercent);
        }

        private void PlaySound(float healthPercent)
        {
            for (int i = this.audioClips.Length - 1; i >= 0; i--)
            {
                Sound sound = this.audioClips[i];
                if (sound.percent >= healthPercent)
                {
                    AudioClip damageSFX = sound.RandomClip();
                    this.audioSource.PlayOneShot(damageSFX);
                    return;
                }
            }
        }

        [Serializable]
        private struct Sound
        {
            [SerializeField, Range(0.01f, 1.0f)]
            public float percent;

            [SerializeField]
            private AudioClip[] clips;

            public AudioClip RandomClip()
            {
                var index = Random.Range(0, this.clips.Length);
                return this.clips[index];
            }
        }
    }
}