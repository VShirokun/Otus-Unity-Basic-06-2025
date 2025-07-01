using UnityEngine;

namespace Game.Engine
{
    [RequireComponent(typeof(AudioSource))]
    public sealed class FireWeaponSoundTrigger : MonoBehaviour
    {
        [SerializeField]
        private Weapon weapon;
        
        private AudioSource audioSource;

        [SerializeField, Range(0, 2)]
        private float minPitch = 1.0f;

        [SerializeField, Range(0, 2)]
        private float maxPitch = 1.15f;

        private void Awake()
        {
            this.audioSource = this.GetComponent<AudioSource>();
        }

        private void OnEnable()
        {
            this.weapon.OnFire += this.OnWeaponFire;
        }

        private void OnDisable()
        {
            this.weapon.OnFire -= this.OnWeaponFire;
        }

        private void OnWeaponFire()
        {
            this.audioSource.pitch = Random.Range(this.minPitch, this.maxPitch);
            this.audioSource.Play();
        }
    }
}