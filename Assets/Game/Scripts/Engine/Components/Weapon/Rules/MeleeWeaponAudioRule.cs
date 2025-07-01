using System;
using Game.Engine;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game.Content
{
    [Serializable]
    public sealed class MeleeWeaponAudioRule : IWeaponRule
    {
        [SerializeField]
        private string animEvent;

        [Space]
        [SerializeField, Range(0, 2)]
        private float minPitch = 0.4f;

        [SerializeField, Range(0, 2)]
        private float maxPitch = 0.6f;

        private AudioSource _audioSource;
        private AnimationEventListener _animationListener;

        public void OnEnable(GameObject owner, Weapon weapon)
        {
            _audioSource = weapon.GetComponentInChildren<AudioSource>();
            _animationListener = owner.GetComponentInChildren<AnimationEventListener>();
            _animationListener.OnMessageReceived += this.OnAnimEvent;
        }

        public void OnDisable(GameObject owner, Weapon weapon)
        {
            _animationListener.OnMessageReceived -= this.OnAnimEvent;
        }

        private void OnAnimEvent(string message)
        {
            if (this.animEvent == message)
            {
                _audioSource.pitch = Random.Range(this.minPitch, this.maxPitch);
                _audioSource.Play();
            }
        }

        public void Update(GameObject owner, Weapon weapon)
        {
        }

        public void FixedUpdate(GameObject owner, Weapon weapon)
        {
        }

        public void LateUpdate(GameObject owner, Weapon weapon)
        {
        }
    }
}