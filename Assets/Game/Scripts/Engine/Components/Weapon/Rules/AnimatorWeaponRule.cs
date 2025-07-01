using System;
using Animancer;
using UnityEngine;

namespace Game.Engine
{
    [Serializable]
    public sealed class AnimatorWeaponRule : IWeaponRule
    {
        [SerializeField]
        private RuntimeAnimatorController animatorController;

        private ControllerState _animState;

        public void OnEnable(GameObject owner, Weapon weapon)
        {
            _animState ??= new ControllerState(this.animatorController);

            HybridAnimancerComponent animator = owner.GetComponentInChildren<HybridAnimancerComponent>();
            animator.Play(_animState, 0.25f);
            // Animator animator = owner.GetComponentInChildren<Animator>();
            // animator.runtimeAnimatorController = this.animatorController;
        }

        public void OnDisable(GameObject owner, Weapon weapon)
        {
            Animator animator = owner.GetComponentInChildren<Animator>();
            animator.runtimeAnimatorController = null;
        }

        public void Update(GameObject owner, Weapon weapon)
        {
        }

        public void FixedUpdate(GameObject owner, Weapon weapon)
        {
        }

        public void LateUpdate(GameObject owner, Weapon weapon)
        {
        }
    }
}