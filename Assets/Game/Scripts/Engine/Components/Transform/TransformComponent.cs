using UnityEngine;

namespace Game.Engine
{
    public sealed class TransformComponent : MonoBehaviour
    {
        public Transform Transform => this.mainTransform; 
        
        [SerializeField]
        private Transform mainTransform;

        private void Reset()
        {
            this.mainTransform = this.transform;
        }
    }
}