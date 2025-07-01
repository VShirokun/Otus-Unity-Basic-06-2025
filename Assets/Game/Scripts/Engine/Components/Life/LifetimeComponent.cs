using System;
using UnityEngine;

namespace Game.Engine
{
    public sealed class LifetimeComponent : MonoBehaviour
    {
        public float CurrentTime
        {
            get => this.currentTime;
            set => this.currentTime = value;
        }

        [SerializeField]
        private float lifetime = 2;

        [SerializeField]
        private float currentTime;

        public void Reset()
        {
            this.currentTime = this.lifetime;
        }

        private void FixedUpdate()
        {
            if (this.currentTime > 0)
            {
                this.currentTime -= Time.fixedDeltaTime;
            }
        }
    }
}