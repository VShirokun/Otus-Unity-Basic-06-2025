using Animancer;
using UnityEngine;

namespace Game.Engine
{
    public sealed class CharacterFistsController : MonoBehaviour
    {
        private const string LEFT_FIST_EVENT = "left_fist_hit";
        private const string RIGHT_FIST_EVENT = "right_fist_hit";

        [SerializeField]
        private GameObject owner;

        [SerializeField]
        private MeleeWeapon leftFist;

        [SerializeField]
        private MeleeWeapon rightFist;

        [SerializeField]
        private RuntimeAnimatorController animatorController;
        
        private AnimationEventListener _animationListener;
        private WeaponComponent _weaponComponent;
        private HybridAnimancerComponent _animator;
        private ControllerState _animState;

        private void Awake()
        {
            _animState = new ControllerState(this.animatorController); 
            _animator = this.owner.GetComponentInChildren<HybridAnimancerComponent>();
            _animationListener = this.owner.GetComponentInChildren<AnimationEventListener>();
            _weaponComponent = this.owner.GetComponent<WeaponComponent>();
        }

        private void OnEnable()
        {
            this.OnWeaponChanged(_weaponComponent.GetCurrentWeapon());
            _weaponComponent.OnWeaponChanged += this.OnWeaponChanged;
            _animationListener.OnMessageReceived += this.OnAnimEvent;
        }

        private void OnWeaponChanged(Weapon weapon)
        {
            if (weapon == null)
            {
                _animator.Play(_animState, 0.25f);
            }
        }

        private void OnDisable()
        {
            _weaponComponent.OnWeaponChanged -= this.OnWeaponChanged;
            _animationListener.OnMessageReceived -= this.OnAnimEvent;
        }

        private void OnAnimEvent(string animEvent)
        {
            if (animEvent == LEFT_FIST_EVENT)
            {
                this.leftFist.Fire();
            }
            else if (animEvent == RIGHT_FIST_EVENT)
            {
                this.rightFist.Fire();
            }
        }
    }
}