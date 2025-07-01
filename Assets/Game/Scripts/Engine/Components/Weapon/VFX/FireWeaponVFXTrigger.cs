using UnityEngine;

namespace Game.Engine
{
    public sealed class FireWeaponVFXTrigger : MonoBehaviour
    {
        [SerializeField]
        private Weapon weapon;

        [SerializeField]
        private ParticleSystem vfx;

        private void OnEnable()
        {
            this.weapon.OnFire += this.OnWeaponFire;
        }

        private void OnDisable()
        {
            this.weapon.OnFire -= this.OnWeaponFire;
        }

        private void OnWeaponFire()
        {
            this.vfx.Play(withChildren: true);
        }
    }
}