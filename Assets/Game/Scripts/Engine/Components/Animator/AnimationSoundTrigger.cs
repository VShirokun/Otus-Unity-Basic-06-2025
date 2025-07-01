using System;
using UnityEngine;

namespace Game.Engine
{
    [RequireComponent(typeof(AudioSource))]
    public sealed class AnimationSoundTrigger : MonoBehaviour
    {
        [SerializeField]
        private AnimationEventListener animationListener;

        [SerializeField]
        private Event[] soundEvents;

        private AudioSource audioSource;
        
        private void Awake()
        {
            this.audioSource = this.GetComponent<AudioSource>();
        }

        private void OnEnable()
        {
            this.animationListener.OnMessageReceived += this.OnAnimEvent;
        }

        private void OnDisable()
        {
            this.animationListener.OnMessageReceived -= this.OnAnimEvent;
        }

        private void OnAnimEvent(string message)
        {
            for (int i = 0, count = this.soundEvents.Length; i < count; i++)
            {
                Event soundEvent = this.soundEvents[i];
                if (soundEvent.message == message)
                {
                    this.audioSource.PlayOneShot(soundEvent.clip);
                }
            }
        }
        
        [Serializable]
        private struct Event
        {
            public string message;
            public AudioClip clip;
        }
    }
}