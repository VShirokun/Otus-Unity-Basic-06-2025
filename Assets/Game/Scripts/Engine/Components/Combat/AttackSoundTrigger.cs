using System.Collections.Generic;
using UnityEngine;

namespace Game.Engine
{
    public sealed class AttackSoundTrigger : MonoBehaviour
    {
        private const string ATTACK_EVENT = "start_attack_event";
        
        [SerializeField]
        private AnimationEventListener animationListener;

        [SerializeField]
        private AudioClip[] audioClips;

        private AudioSource audioSource;
        
        private readonly List<AudioClip> availableClips = new();
        
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
            if (message != ATTACK_EVENT)
            {
                return;
            }
            
            //TODO: вынести в отдельный класс и выдавать рандомную дорожку
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