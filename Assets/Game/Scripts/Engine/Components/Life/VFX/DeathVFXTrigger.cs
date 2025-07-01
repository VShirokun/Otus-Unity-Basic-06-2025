using UnityEngine;

namespace Game.Engine
{
    public sealed class DeathVFXTrigger : MonoBehaviour
    {
        [SerializeField, Space]
        private LifeComponent lifeComponent;

        [SerializeField]
        private ParticleSystem[] vfxList;

        private void OnEnable()
        {
            this.lifeComponent.OnDeath += this.OnDeath;
        }

        private void OnDisable()
        {
            this.lifeComponent.OnDeath -= this.OnDeath;
        }

        private void OnDeath(GameObject source, int damage)
        {
            foreach (var vfx in this.vfxList)
            {
                vfx.Play(withChildren: true);
            }
        }
    }
}