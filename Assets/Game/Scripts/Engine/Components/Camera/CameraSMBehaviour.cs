using Cinemachine;
using UnityEngine;

namespace Game.Engine
{
    public sealed class CameraSMBehaviour : StateMachineBehaviour
    {
        [SerializeField]
        private CameraType cameraType;

        private CinemachineVirtualCamera _camera;

        public override void OnStateMachineEnter(Animator animator, int stateMachinePathHash)
        {
            if (_camera == null)
            {
                _camera = ServiceLocator.GetService<CameraService>().GetCamera(this.cameraType);
            }

            _camera.enabled = true;
        }

        public override void OnStateMachineExit(Animator animator, int stateMachinePathHash)
        {
            _camera.enabled = false;
        }

        //
        // [SerializeField]
        // private string tag;

        
        // public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        // {
        //     if (!stateInfo.IsTag(this.tag))
        //     {
        //         return;
        //     }
        //
        //     
        // }

        // public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        // {
        //     if (!stateInfo.IsTag(this.tag))
        //     {
        //         return;
        //     }
        //    
        // }
    }
}