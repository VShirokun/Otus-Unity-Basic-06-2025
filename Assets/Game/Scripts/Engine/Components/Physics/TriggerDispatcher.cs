using System;
using UnityEngine;

namespace Game.Engine
{
    public sealed class TriggerDispatcher : MonoBehaviour
    {
        public event Action<Collider> OnEntered;
        public event Action<Collider> OnExited;

        private void OnTriggerEnter(Collider other)
        {
            this.OnEntered?.Invoke(other);
        }

        private void OnTriggerExit(Collider other)
        {
            this.OnExited?.Invoke(other);
        }
    }
}