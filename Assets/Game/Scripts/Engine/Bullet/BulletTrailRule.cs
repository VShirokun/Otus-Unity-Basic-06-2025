using System;
using System.Threading.Tasks;
using UnityEngine;

namespace Game.Engine
{
    public sealed class BulletTrailRule : MonoBehaviour
    {
        [SerializeField]
        private TrailRenderer trailPrefab;
        
        [SerializeField, Space]
        private Transform trailParent;

        [SerializeField]
        private Vector3 trailScale = new(5, 5, 2.5f);

        [SerializeField]
        private Vector3 trailOffset = new(0, 0, -1.5f);

        private GameObjectPool objectPool;

        private TrailRenderer _trail;

        public void Show()
        {
            if (this.objectPool == null)
            {
                this.objectPool = ServiceLocator.GetService<GameObjectPool>();
            }

            _trail = this.objectPool.Get(this.trailPrefab);
            
            Transform tranform = _trail.transform;
            tranform.parent = this.trailParent;
            tranform.localScale = this.trailScale;
            tranform.localPosition = this.trailOffset;
            tranform.localEulerAngles = Vector3.zero;
            
            _trail.SetPositions(Array.Empty<Vector3>());
            _trail.Clear();
            _trail.emitting = true;
        }

        public void Hide()
        {
            if (_trail != null)
            {
                this.UnspawnTrail(_trail);
                _trail = null;   
            }
        }

        private async void UnspawnTrail(TrailRenderer trail)
        {
            trail.transform.parent = null;
            await Task.Delay(Mathf.RoundToInt(trail.time * 1000));
            trail.emitting = false;
            this.objectPool.Release(trail, inContainer: true);
        }
    }
}