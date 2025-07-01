using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Events;

namespace Game.Engine
{
    internal sealed class AnimationEventListener : MonoBehaviour
    {
        public event Action<string> OnMessageReceived; 

        [SerializeField]
        private Event[] events;
        
        [UsedImplicitly]
        internal void ReceiveEvent(string message)
        {
            for (int i = 0, count = this.events.Length; i < count; i++)
            {
                Event @event = this.events[i];
                if (@event.message == message)
                {
                    @event.action.Invoke();
                }
            }
            
            this.OnMessageReceived?.Invoke(message);
        }
        
        [Serializable]
        private struct Event
        {
            [SerializeField]
            internal string message;
        
            [SerializeField]
            internal UnityEvent action;
        }
    }
}