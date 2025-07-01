using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Engine
{
    public sealed class WeaponComponent : MonoBehaviour
    {
        public event Action<Weapon> OnWeaponChanged;

        [SerializeField]
        private Weapon currentWeapon;

        public bool TryGetCurrentWeapon(out Weapon weapon)
        {
            weapon = this.currentWeapon;
            return this.currentWeapon != null;
        }

        public bool TryGetComponentOfWeapon<T>(out T result) where T : class
        {
            if (this.currentWeapon == null)
            {
                result = default;
                return false;
            }

            return this.currentWeapon.TryGetComponent(out result);
        }

        public Weapon GetCurrentWeapon()
        {
            return this.currentWeapon;
        }

        [Button]
        public void SetCurrentWeapon(Weapon weapon)
        {
            this.currentWeapon = weapon;
            this.OnWeaponChanged?.Invoke(weapon);
        }

        public bool HasWeapon()
        {
            return this.currentWeapon != null;
        }

        public bool CanFire()
        {
            return this.currentWeapon != null && this.currentWeapon.CanFire();
        }

        public void Fire()
        {
            if (this.currentWeapon != null)
            {
                this.currentWeapon.Fire();
            }
        }
    }
}