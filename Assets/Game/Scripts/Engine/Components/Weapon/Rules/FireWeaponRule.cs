using System;
using UnityEngine;

namespace Game.Engine
{
    [Serializable]
    public class FireWeaponRule : IWeaponRule
    {
        [SerializeField]
        private string fireEvent = "fire_event";

        private AnimationEventListener _animationListener;
        private Weapon _weapon;

        public virtual void OnEnable(GameObject owner, Weapon weapon)
        {
            _weapon = weapon;
            _animationListener = owner.GetComponentInChildren<AnimationEventListener>();
            _animationListener.OnMessageReceived += this.OnMessageReceived;
        }

        public virtual void OnDisable(GameObject owner, Weapon weapon)
        {
            _animationListener.OnMessageReceived -= this.OnMessageReceived;
        }

        private void OnMessageReceived(string message)
        {
            if (message == this.fireEvent)
            {
                _weapon.Fire();
            }
        }

        public virtual void Update(GameObject owner, Weapon weapon)
        {
        }

        public virtual void FixedUpdate(GameObject owner, Weapon weapon)
        {
        }

        public virtual void LateUpdate(GameObject owner, Weapon weapon)
        {
        }
    }
}