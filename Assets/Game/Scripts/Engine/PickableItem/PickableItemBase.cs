using UnityEngine;

namespace Game.Engine
{
    public abstract class PickableItemBase : PickableItem
    {

        [SerializeField]
        private GameObject visual;

        [SerializeField]
        private ParticleSystem pickUpVFX;

        [SerializeField]
        private AudioSource audioSource;

        [SerializeField]
        private new Collider collider;

        public sealed override bool PickUp(GameObject target)
        {
            if (!this.ProcessPickUp(target))
            {
                return false;
            }

            if (this.visual != null)
            {
                this.visual.SetActive(false);
            }

            if (this.pickUpVFX != null)
            {
                this.pickUpVFX.Play(true);
            }

            if (this.audioSource != null)
            {
                this.audioSource.Play();
            }
            
            this.collider.enabled = false;
            return true;
        }

        protected abstract bool ProcessPickUp(GameObject target);
    }
}