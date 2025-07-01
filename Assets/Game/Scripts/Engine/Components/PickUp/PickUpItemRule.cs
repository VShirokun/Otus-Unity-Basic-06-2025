using UnityEngine;

namespace Game.Engine
{
    [RequireComponent(typeof(PickUpComponent))]
    public sealed class PickUpItemRule : MonoBehaviour
    {
        private PickUpComponent pickUpComponent;
        
        private void Awake()
        {
            this.pickUpComponent = this.GetComponent<PickUpComponent>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out PickableItem item))
            {
                this.pickUpComponent.PickUp(item);
            }
        }
    }
}