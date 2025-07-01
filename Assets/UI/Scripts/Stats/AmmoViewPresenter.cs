using Game.Engine;
using UnityEngine;

namespace Game.UI
{
    [RequireComponent(typeof(StatView))]
    internal sealed class AmmoViewPresenter : MonoBehaviour
    {
        private StatView ammoView;

        private WeaponComponent _weaponComponent;
        private BulletMagazine _currentMagazine;

        private void Awake()
        {
            this.ammoView = this.GetComponent<StatView>();
            this.ammoView.SetProgress(1);
        }

        private void Start()
        {
            GameObject character = ServiceLocator.GetService<ICharacterService>().Character;
            _weaponComponent = character.GetComponent<WeaponComponent>();
            _weaponComponent.OnWeaponChanged += this.OnWeaponChanged;
            this.OnWeaponChanged(_weaponComponent.GetCurrentWeapon());
        }

        private void OnDestroy()
        {
            _weaponComponent.OnWeaponChanged -= this.OnWeaponChanged;
        }

        private void OnWeaponChanged(Weapon weapon)
        {
            if (_currentMagazine != null)
            {
                _currentMagazine.OnStateChanged -= this.OnMagazineStateChanged;
            }

            if (weapon == null || !weapon.TryGetComponent(out BulletMagazine magazine))
            {
                this.ammoView.gameObject.SetActive(false);
                return;
            }
            
            this.ammoView.gameObject.SetActive(true);

            _currentMagazine = magazine;
            _currentMagazine.OnStateChanged += this.OnMagazineStateChanged;

            this.OnMagazineStateChanged();
        }
        
        private void OnMagazineStateChanged()
        {
            var bulletCount = _currentMagazine.GetBulletCount();
            this.ammoView.SetText(bulletCount.ToString());
            // this.ammoView.SetProgress((float) bulletCount / 10);
        }
    }
}