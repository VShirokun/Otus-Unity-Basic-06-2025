using UnityEngine;

namespace Game.Engine
{
    // [RequireComponent(typeof(RotateComponent))]
    // public sealed class RotateTransformRule : MonoBehaviour
    // {
    //     private RotateComponent rotateComponent;
    //
    //
    //     
    //     private void Awake()
    //     {
    //         this.rotateComponent = this.GetComponent<RotateComponent>();
    //     }
    //
    //     private void FixedUpdate()
    //     {
    //         if (this.rotateComponent.IsRotating())
    //         {
    //             float percent = this.rotationSpeed * Time.fixedDeltaTime;
    //             Vector3 direction = this.rotateComponent.GetDirection();
    //             
    //             Quaternion currentRotation = this.rotationTransform.rotation;
    //             Quaternion targetRotation = Quaternion.LookRotation(direction);
    //             Quaternion nextRotation = Quaternion.Slerp(currentRotation, targetRotation, percent);
    //             this.rotationTransform.rotation = nextRotation;
    //         }
    //     }
    // }
}