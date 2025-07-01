using System;
using UnityEngine;

namespace Game.Engine
{
    [Serializable]
    public sealed class CameraShakeWeaponRule : IWeaponRule
    {
        [SerializeField]
        private float shakeMagnitude = 0.4f;
        
        [SerializeField]
        private float shakeFrequency = 2.0f;

        [SerializeField]
        private float shakeDuration = 0.1f;

        private Weapon _weapon;
        private ICameraShaker _cameraShaker;

        void IWeaponRule.OnEnable(GameObject owner, Weapon weapon)
        {
            _cameraShaker = ServiceLocator.GetService<ICameraShaker>();
            
            _weapon = weapon;
            _weapon.OnFire += this.OnWeaponFire;
        }

        void IWeaponRule.OnDisable(GameObject owner, Weapon weapon)
        {
            _weapon.OnFire -= this.OnWeaponFire;
        }

        private void OnWeaponFire()
        {
            _cameraShaker.SetShake(_weapon.name, this.shakeMagnitude, this.shakeFrequency, this.shakeDuration);
        }

        void IWeaponRule.Update(GameObject owner, Weapon weapon)
        {
        }

        void IWeaponRule.FixedUpdate(GameObject owner, Weapon weapon)
        {
        }

        void IWeaponRule.LateUpdate(GameObject owner, Weapon weapon)
        {
        }
    }
}