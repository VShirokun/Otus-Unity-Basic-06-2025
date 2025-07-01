using System;
using UnityEngine;

namespace Game.Engine
{
    public sealed class PickUpComponent : MonoBehaviour
    {
        public event Action<PickableItem> OnPickedUp; 

        [SerializeField]
        private GameObject owner;
        
        public bool PickUp(PickableItem item)
        {
            if (item.PickUp(this.owner))
            {
                this.OnPickedUp?.Invoke(item);
                return true;
            }

            return false;
        }
        
        private void Reset()
        {
            this.owner = this.gameObject;
        }
    }
}