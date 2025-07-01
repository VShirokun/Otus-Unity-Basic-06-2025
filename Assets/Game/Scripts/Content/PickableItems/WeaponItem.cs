using Game.Engine;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Content
{
    public sealed class WeaponItem : PickableItemBase
    {
        public override string Id => this.weaponName;
        
        //TODO: СДЕЛАТЬ ССЫЛКУ НА WEAPON CONFIG
        [SerializeField]
        private string weaponName;

        [SerializeField]
        private bool hasBullets;

        [ShowIf(nameof(hasBullets))]
        [SerializeField]
        private int bullets = 8;
        
        //TODO: СДЕЛАТЬ АДЕКВАТНОЕ ДОБАВЛЕНИЕ ОРУЖИЯ ЧЕРЕЗ WEAPON MANAGER 

        protected override bool ProcessPickUp(GameObject target)
        {
            if (!target.TryGetComponent(out WeaponComponent weaponComponent))
            {
                return false;
            }

            Weapon[] weapons = target.GetComponentsInChildren<Weapon>(includeInactive: true);
            foreach (var weapon in weapons)
            {
                if (weapon.name == this.weaponName)
                {
                    weaponComponent.SetCurrentWeapon(weapon);
                    if (this.hasBullets && weapon.TryGetComponent(out BulletMagazine magazine))
                    {
                        magazine.AddBullets(this.bullets);
                    }
                    return true;
                }
            }

            return false;
        }
    }
}