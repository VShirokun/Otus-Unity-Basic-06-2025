using Game.Engine;
using UnityEngine;

namespace Game.Content
{
    public sealed class AmmoItem : PickableItemBase
    {
        [SerializeField, Space]
        private int charges = 10;

        public override string Id => this.name;

        protected override bool ProcessPickUp(GameObject target)
        {
            if (target.TryGetComponent(out WeaponComponent weaponHolder) &&
                weaponHolder.TryGetComponentOfWeapon(out BulletMagazine magazine))
            {
                magazine.AddBullets(this.charges);
                return true;
            }

            return false;
        }
    }
}