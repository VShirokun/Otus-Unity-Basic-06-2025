using UnityEngine;

namespace Game.Engine
{
    [RequireComponent(typeof(DealDamageAction))]
    public class MeleeWeapon : WeaponBase
    {
        private static readonly Collider[] buffer = new Collider[32];

        [SerializeField, Space]
        private int damage = 1;

        [SerializeField, Space]
        private Mode mode = Mode.FIRST;

        [SerializeField]
        private Transform meleePoint;

        [SerializeField]
        private float meleeRadius = 0.2f;
        
        [SerializeField]
        private LayerMask layerMask;

        private DealDamageAction damageAction;

        private void Awake()
        {
            this.damageAction = this.GetComponent<DealDamageAction>();
        }
        
        protected override void ProcessFire()
        {
            this.DealDamage();
        }

        private void DealDamage()
        {
            Vector3 center = this.meleePoint.position;
            int size = Physics.OverlapSphereNonAlloc(center, this.meleeRadius, buffer, this.layerMask);

            if (this.mode == Mode.FIRST)
            {
                for (int i = 0; i < size; i++)
                {
                    Collider collider = buffer[i];
                    if (this.damageAction.DealDamage(collider, this.damage))
                    {
                        return;
                    }
                }
            }
            else if (this.mode == Mode.ALL)
            {
                for (int i = 0; i < size; i++)
                {
                    Collider collider = buffer[i];
                    this.damageAction.DealDamage(collider, this.damage);
                }
            }
        }

        private void OnDrawGizmos()
        {
            if (this.meleePoint != null)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawWireSphere(this.meleePoint.position, this.meleeRadius);
            }
        }

        private enum Mode
        {
            FIRST = 0,
            ALL = 1,
        }
    }
}