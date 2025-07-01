using UnityEngine;

namespace Game.Engine
{
    public sealed class ResetWeaponIfEmptyRule : MonoBehaviour
    {
        [SerializeField]
        private WeaponComponent weaponComponent;

        private BulletMagazine _weaponMagazine;

        public void OnEnable()
        {
            this.weaponComponent.OnWeaponChanged += this.OnWeaponChanged;
            this.OnWeaponChanged(this.weaponComponent.GetCurrentWeapon());
        }

        public void OnDisable()
        {
            this.weaponComponent.OnWeaponChanged += this.OnWeaponChanged;
        }

        private void OnWeaponChanged(Weapon weapon)
        {
            if (_weaponMagazine != null)
            {
                _weaponMagazine.OnStateChanged -= this.OnAmmoStateChanged;
            }

            if (weapon == null)
            {
                return;
            }

            _weaponMagazine = weapon.GetComponent<BulletMagazine>();
            if (_weaponMagazine != null)
            {
                _weaponMagazine.OnStateChanged += this.OnAmmoStateChanged;
            }
        }

        private void OnAmmoStateChanged()
        {
            if (_weaponMagazine.HasBullets())
            {
                return;
            }

            this.weaponComponent.SetCurrentWeapon(null);
        }
    }
}