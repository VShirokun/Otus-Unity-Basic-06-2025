using UnityEngine;

namespace Game.Engine
{
    public sealed class SmoothRotateAction : MonoBehaviour
    {
        [SerializeField]
        private Transform rotationTransform;

        [SerializeField, Range(1, 50)]
        private float rotationSpeed = 25.0f;

        public void RotateTowards(Vector3 direction, Vector3 axis, float deltaTime)
        {
            this.RotateTowards(direction, axis, deltaTime, this.rotationSpeed);
        }
        
        public void RotateTowards(Vector3 direction, Vector3 axis, float deltaTime, float speed)
        {
            float percent = speed * deltaTime;
            Quaternion currentRotation = this.rotationTransform.rotation;
            Quaternion targetRotation = Quaternion.LookRotation(direction, axis);
            Quaternion nextRotation = Quaternion.Slerp(currentRotation, targetRotation, percent);
            this.rotationTransform.rotation = nextRotation;
        }
    }
}