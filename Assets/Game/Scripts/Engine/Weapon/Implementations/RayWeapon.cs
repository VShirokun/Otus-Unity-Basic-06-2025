using UnityEngine;

namespace Game.Engine
{
    [RequireComponent(typeof(DealDamageAction))]
    public class RayWeapon : WeaponBase
    {
        [SerializeField, Space]
        private int damage = 1;
        
        [SerializeField, Space]
        private Transform firePoint;

        [SerializeField]
        private float maxDistance = 10;

        [SerializeField]
        private LayerMask layerMask;

        private DealDamageAction damageAction;

        private void Awake()
        {
            this.damageAction = this.GetComponent<DealDamageAction>();
        }

        protected override void ProcessFire()
        {
            Ray ray = new Ray(this.firePoint.position, this.firePoint.forward);
            if (Physics.Raycast(ray, out RaycastHit hit, this.maxDistance, this.layerMask))
            {
                this.damageAction.DealDamage(hit.collider, this.damage);
            }
        }
    }
}