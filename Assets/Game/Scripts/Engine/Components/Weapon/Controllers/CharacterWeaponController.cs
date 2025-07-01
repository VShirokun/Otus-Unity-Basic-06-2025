using System;
using UnityEngine;

namespace Game.Engine
{
    public sealed class CharacterWeaponController : MonoBehaviour
    {
        [SerializeField]
        private GameObject owner;

        [SerializeField]
        private WeaponRules[] controllers;

        private WeaponComponent _weaponComponent;

        private Weapon _currentWeapon;
        private IWeaponRule[] _currentRules;

        private void Awake()
        {
            _weaponComponent = this.owner.GetComponent<WeaponComponent>();
        }

        private void OnEnable()
        {
            this.OnWeaponChanged(_weaponComponent.GetCurrentWeapon());
            _weaponComponent.OnWeaponChanged += this.OnWeaponChanged;
        }

        private void OnDisable()
        {
            _weaponComponent.OnWeaponChanged -= this.OnWeaponChanged;
        }

        private void Update()
        {
            if (_currentRules != null)
            {
                for (int i = 0, count = _currentRules.Length; i < count; i++)
                {
                    IWeaponRule rule = _currentRules[i];
                    rule.Update(this.owner, _currentWeapon);
                }
            }
        }

        private void FixedUpdate()
        {
            if (_currentRules != null)
            {
                for (int i = 0, count = _currentRules.Length; i < count; i++)
                {
                    IWeaponRule rule = _currentRules[i];
                    rule.FixedUpdate(this.owner, _currentWeapon);
                }
            }
        }

        private void LateUpdate()
        {
            if (_currentRules != null)
            {
                for (int i = 0, count = _currentRules.Length; i < count; i++)
                {
                    IWeaponRule rule = _currentRules[i];
                    rule.LateUpdate(this.owner, _currentWeapon);
                }
            }
        }

        private void OnWeaponChanged(Weapon weapon)
        {
            //Disable previous weapon:
            if (_currentWeapon != null)
            {
                _currentWeapon.gameObject.SetActive(false);
            }

            if (_currentRules != null)
            {
                for (int i = 0, count = _currentRules.Length; i < count; i++)
                {
                    IWeaponRule rule = _currentRules[i];
                    rule.OnDisable(this.owner, _currentWeapon);
                }
            }

            _currentWeapon = weapon;
            
            //Enable weapon:
            if (_currentWeapon == null)
            {
                return;
            }

            this.UpdateRules(weapon, out _currentRules);
            _currentWeapon.gameObject.SetActive(true);


            if (_currentRules != null)
            {
                for (int i = 0, count = _currentRules.Length; i < count; i++)
                {
                    IWeaponRule rule = _currentRules[i];
                    rule.OnEnable(this.owner, _currentWeapon);
                }
            }
        }

        private void UpdateRules(Weapon weapon, out IWeaponRule[] rules)
        {
            foreach (WeaponRules info in this.controllers)
            {
                if (info.weapon == weapon)
                {
                    rules = info.rules;
                    return;
                }
            }

            rules = null;
        }

        [Serializable]
        private struct WeaponRules
        {
            [SerializeField]
            public Weapon weapon;

            [SerializeReference]
            public IWeaponRule[] rules;
        }
    }
}