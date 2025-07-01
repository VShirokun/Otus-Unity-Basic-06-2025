using UnityEngine;

namespace Game.Engine
{
    public sealed class BodyFallBloodTrigger : MonoBehaviour
    {
        private const string FALL_ANIM_EVENT = "body_fall_event"; 
        
        [SerializeField]
        private AnimationEventListener animationListener;
        
        [SerializeField]
        private ParticleSystem bloodSFX;

        [SerializeField]
        private Transform spine;

        [SerializeField]
        private float offsetY = 0; 

        private void OnEnable()
        {
            this.animationListener.OnMessageReceived += this.OnAnimEvent;
        }

        private void OnDisable()
        {
            this.animationListener.OnMessageReceived -= this.OnAnimEvent;
        }

        private void OnAnimEvent(string message)
        {
            if (message != FALL_ANIM_EVENT)
            {
                return;
            }
            
            Vector3 spinePosition = this.spine.position;
            Vector3 sfxPosition = this.bloodSFX.transform.position;

            this.bloodSFX.transform.parent = null; //TODO: Временно, сделать через пул и рейкасты!
            this.bloodSFX.transform.position = new Vector3(spinePosition.x, this.offsetY, spinePosition.z);
            this.bloodSFX.Play(withChildren: true);
        }
    }
}