using System;
using System.Collections;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Engine
{
    public abstract class WeaponBase : Weapon
    {
        public sealed override event Action OnFire;

        [SerializeField]
        private float countdown = 1.0f;
        
        [SerializeField]
        private bool unlimited;
        
        [SerializeField, HideIf(nameof(unlimited))]
        private BulletMagazine bulletMagazine;
        
        private Coroutine countdownCoroutine;

        public override bool CanFire()
        {
            return this.countdownCoroutine == null && (this.unlimited || this.bulletMagazine.HasBullets());
        }

        public sealed override void Fire()
        {
            if (!this.CanFire())
            {
                return;
            }

            this.ProcessFire();

            if (!this.unlimited)
            {
                this.bulletMagazine.SpendBullet();
            }

            if (this.countdown > 0 && this.gameObject.activeInHierarchy)
            {
                this.countdownCoroutine = this.StartCoroutine(this.CoutndownRoutine());
            }
            
            this.OnFire?.Invoke();
        }

        protected abstract void ProcessFire();

        private IEnumerator CoutndownRoutine()
        {
            yield return new WaitForSeconds(this.countdown);
            this.countdownCoroutine = null;
        }
    }
}