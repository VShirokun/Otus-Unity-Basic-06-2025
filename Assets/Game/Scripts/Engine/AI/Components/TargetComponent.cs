using System;
using UnityEngine;

namespace Game.Engine
{
    public sealed class TargetComponent : MonoBehaviour
    {
        public event Action<GameObject> OnTargetChanged; 

        [SerializeField]
        private GameObject target;

        public bool TryGetTarget(out GameObject target)
        {
            target = this.target;
            return this.target != null;
        }

        public bool HasTarget()
        {
            return this.target != null;
        }
        
        public GameObject GetTarget()
        {
            return this.target;
        }

        public void ResetTarget()
        {
            this.target = null;
            this.OnTargetChanged?.Invoke(null);
        }
        
        public void SetTarget(GameObject target)
        {
            this.target = target;
            this.OnTargetChanged?.Invoke(target);
        }
    }
}