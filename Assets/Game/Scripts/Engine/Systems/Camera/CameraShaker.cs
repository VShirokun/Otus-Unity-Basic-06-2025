using System.Collections.Generic;
using Cinemachine;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Engine
{
    internal sealed class CameraShaker : MonoBehaviour, ICameraShaker
    {
        private sealed class Shake
        {
            public float magnitude;
            public float frequency;
            public float remainingTime;
        }

        private CinemachineBrain cameraBrain;

        [ShowInInspector, ReadOnly]
        private readonly Dictionary<string, Shake> currentShakes = new();
        private readonly Dictionary<string, Shake> cache = new();

        private void Awake()
        {
            this.cameraBrain = ServiceLocator.GetService<CinemachineBrain>();
        }

        public void SetShake(string shakeType, float magnitude, float frequency, float seconds)
        {
            if (!this.currentShakes.TryGetValue(shakeType, out Shake shake))
            {
                shake = new Shake();
                this.currentShakes.Add(shakeType, shake);
            }

            shake.magnitude = magnitude;
            shake.frequency = frequency;
            shake.remainingTime = seconds;
        }

        private void Update()
        {
            this.UpdateShakes();
        }

        private void LateUpdate()
        {
            this.UpdateNoise();
        }
        
        private void UpdateShakes()
        {
            float deltaTime = Time.deltaTime;

            this.UpdateCache();

            foreach (var (id, shake) in this.cache)
            {
                shake.remainingTime -= deltaTime;
                if (shake.remainingTime <= 0)
                {
                    this.currentShakes.Remove(id);
                }
            }
        }

        private void UpdateCache()
        {
            this.cache.Clear();

            foreach (var (id, shake) in this.currentShakes)
            {
                this.cache.Add(id, shake);
            }
        }

        private void UpdateNoise()
        {
            var liveCamera = this.cameraBrain.ActiveVirtualCamera as CinemachineVirtualCamera;
            if (liveCamera == null)
            {
                return;
            }

            var noise = liveCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
            if (noise == null)
            {
                return;
            }

            float amplitudeGain = 0.0f;
            float frequencyGain = 0.0f;

            foreach (Shake shake in this.currentShakes.Values)
            {
                amplitudeGain += shake.magnitude;

                if (shake.frequency > frequencyGain)
                {
                    frequencyGain = shake.frequency;
                }
            }

            noise.m_AmplitudeGain = amplitudeGain;
            noise.m_FrequencyGain = frequencyGain;
        }
    }
}