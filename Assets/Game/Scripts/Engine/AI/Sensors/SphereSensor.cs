using System;
using UnityEngine;

namespace Game.Engine
{
    public sealed class SphereTargetSensor : TargetSensor
    {
        [SerializeField]
        private Transform center;

        [SerializeField]
        private float radius;
        
        protected override int ScanColliders(Collider[] buffer)
        {
            return Physics.OverlapSphereNonAlloc(this.center.position, this.radius, buffer);
        }

        private void OnDrawGizmos()
        {
            if (this.center  != null)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawWireSphere(this.center.position, this.radius);   
            }
        }
    }
}