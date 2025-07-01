using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace Game.Lessons.Optimization
{
    public class MonoPool : MonoBehaviour
    {
        [SerializeField] private Transform _deactivateContainer;
        
        private readonly Queue<GameObject> _activePool = new();
        private readonly Queue<GameObject> _inactivePool = new();

        private ObjectPool<GameObject> _objectPool;
        
        
        public GameObject Spawn(GameObject prefab, Vector3 position, Quaternion quaternion, Transform container)
        {
            if (_inactivePool.TryDequeue(out var result))
            {
                result.transform.SetParent(container);
            }
            else
            {
                result = Instantiate(prefab, position, quaternion, container);
            }
            
            _activePool.Enqueue(result);
            return result;
        }
   
        public void Despawn()
        {
            if (!_activePool.TryDequeue(out var result))
            {
                return;
            }
            
            _inactivePool.Enqueue(result);
            result.transform.SetParent(_deactivateContainer);
        }
    }
}
