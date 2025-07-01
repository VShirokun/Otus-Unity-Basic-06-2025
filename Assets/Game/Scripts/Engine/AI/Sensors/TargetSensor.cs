using UnityEngine;

namespace Game.Engine
{
    public abstract class TargetSensor : MonoBehaviour
    {
        private const float MIN_SCAN_PERIOD = 0.2f;
        private const float MAX_SCAN_PERIOD = 0.3f;

        private static readonly Collider[] buffer = new Collider[32];

        [SerializeField]
        private Transform pivot;
        
        [SerializeField]
        private TargetComponent targetComponent;
        
        private float currentTime;

        private void FixedUpdate()
        {
            if (this.currentTime > 0)
            {
                this.currentTime -= Time.fixedDeltaTime;
            }
            else
            {
                this.targetComponent.SetTarget(this.FindTarget());
                this.currentTime = Random.Range(MIN_SCAN_PERIOD, MAX_SCAN_PERIOD);
            }
        }

        private GameObject FindTarget()
        {
            GameObject target = null;
            
            int count = this.ScanColliders(buffer);
            
            Vector3 pivotPosition = pivot.transform.position;
            float minDistance = float.MaxValue;

            for (int i = 0; i < count; i++)
            {
                Collider collider = buffer[i];
                
                float distance = (collider.transform.position - pivotPosition).sqrMagnitude;
                if (distance <= minDistance)
                {
                    minDistance = distance;
                    target = collider.gameObject;
                }
            }

            return target;
        }

        protected abstract int ScanColliders(Collider[] buffer);
    }
}