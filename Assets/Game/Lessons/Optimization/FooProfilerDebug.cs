using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;

namespace Game.Lessons.Optimization
{
    public class FooProfilerDebug : MonoBehaviour
    {
        [SerializeField] private GameObject _gameObject;
        [SerializeField] private int _count;
        
        public void Update()
        {
            Profiler.BeginSample("On fire");
            
            for (int i = 0; i < _count; i++)
            {
                var spawnedObject = Instantiate(_gameObject);
                Destroy(spawnedObject);
            }
            
            Profiler.EndSample();
        }
    }

    public class UpdateManager : MonoBehaviour
    {
        public List<IUpdateListener> _UpdateListeners;

        public void AddListener(IUpdateListener listener)
        {
            _UpdateListeners.Add(listener);
        }

        private void Update()
        {
            var deltaTime = Time.deltaTime;
            
            for (int i = 0; i < _UpdateListeners.Count; i++)
            {
                _UpdateListeners[i].OnUpdate(deltaTime);
            }
        }
    }

    public interface IUpdateListener
    {
        void OnUpdate(float deltaTime);
    }
}