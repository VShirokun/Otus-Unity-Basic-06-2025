using System;
using UnityEngine;

namespace Game.Engine
{
    [RequireComponent(typeof(AudioSource))]
    public sealed class BodyFallSoundTrigger : MonoBehaviour
    {
        private const string FALL_ANIM_EVENT = "body_fall_event"; 
        
        [SerializeField]
        private AnimationEventListener animationListener;
        
        [SerializeField]
        private AudioClip fallSFX;
        
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
            if (message == FALL_ANIM_EVENT)
            {
                this.audioSource.PlayOneShot(this.fallSFX);
            }
        }
    }
}