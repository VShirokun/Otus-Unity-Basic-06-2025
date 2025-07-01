using System.Collections.Generic;
using UnityEngine;

namespace Game.Engine
{
    [RequireComponent(typeof(AudioSource))]
    public sealed class MoveStepSoundTrigger : MonoBehaviour
    {
        private const string MOVE_STEP_EVENT = "move_step_event";
        
        private AudioSource audioSource;

        [SerializeField]
        private AnimationEventListener animationListener;
        
        [SerializeField]
        private AudioClip[] audioClips;

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
            if (message == MOVE_STEP_EVENT)
            {
                this.PlayMoveStep();
            }
        }

        private void PlayMoveStep()
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