using System;
using System.Collections;
using System.Collections.Generic;
using NTC.Pool;
using UnityEngine;

namespace Game.Lessons.Optimization
{
    public class ObjectSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject _prefab;
        [SerializeField] private int _count = 20;
        [SerializeField] private MonoPool _monoPool;
        [SerializeField] private bool _isSpawned = true;
        [SerializeField] private bool _spawnOnce;
        [SerializeField] private bool _usePool;
        [SerializeField] private float _delay = .1f;

        private List<GameObject> _objects = new();

        private IEnumerator Start()
        {
            if (!_isSpawned)
            {
                yield break; 
            }
            
            var count = _count;
            
            if (_spawnOnce)
            {
                SpawnObjects(count);
                yield break;
            }
            
            while (_isSpawned)
            {
                SpawnObjects(count);
                
                yield return new WaitForSeconds(_delay);
                
                DespawnObjects(count);
            }
        }

        private void DespawnObjects(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Despawn();
            }
        }

        private void SpawnObjects(int count)
        {
            for (int i = 0; i < count; i++)
            {
                var position = Vector3.forward * i;

                Spawn(position);
            }
        }

        private void Spawn(Vector3 position)
        {
            GameObject gameObj;
            
            if (_usePool)
            {
                
                gameObj = NightPool.Spawn(_prefab, position, Quaternion.identity, null);
                // gameObj = _monoPool.Spawn(_prefab, position, Quaternion.identity, null);
            }
            else
            {
                gameObj = Instantiate(_prefab, position, Quaternion.identity, null);
            }
            
            _objects.Add(gameObj);
        }

        private void Despawn()
        {
            var obj = _objects[^1];
            _objects.Remove(obj);
            
            if (_usePool)
            {
                NightPool.Despawn(obj);
                // _monoPool.Despawn();
            }
            else
            {
                Destroy(obj);
            }
        }
    }
}