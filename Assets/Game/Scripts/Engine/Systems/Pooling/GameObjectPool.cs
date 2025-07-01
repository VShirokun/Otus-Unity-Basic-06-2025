using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Engine
{
    public sealed class GameObjectPool : MonoBehaviour
    {
        [ShowInInspector, ReadOnly]
        private readonly Dictionary<string, Queue<GameObject>> gameObjects = new();

        [SerializeField]
        private Transform container;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T Get<T>(T prefab, Transform parent = null) where T : Component
        {
            return this.Get(prefab.gameObject, parent).GetComponent<T>();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T Get<T>(T prefab, Vector3 position, Quaternion rotation, Transform parent) where T : Component
        {
            return this.Get(prefab.gameObject, position, rotation, parent).GetComponent<T>();
        }

        public GameObject Get(GameObject prefab, Transform parent)
        {
            string objectName = prefab.name;

            if (!this.gameObjects.TryGetValue(objectName, out Queue<GameObject> queue))
            {
                queue = new Queue<GameObject>();
                this.gameObjects.Add(objectName, queue);
            }

            if (queue.TryDequeue(out GameObject obj))
            {
                Transform transform = obj.transform;
                transform.parent = parent;
            }
            else
            {
                obj = Instantiate(prefab, parent);
                obj.name = objectName;
            }

            return obj;
        }

        public GameObject Get(GameObject prefab, Vector3 position, Quaternion rotation, Transform parent)
        {
            string objectName = prefab.name;

            if (!this.gameObjects.TryGetValue(objectName, out Queue<GameObject> queue))
            {
                queue = new Queue<GameObject>();
                this.gameObjects.Add(objectName, queue);
            }

            if (queue.TryDequeue(out GameObject obj))
            {
                Transform transform = obj.transform;
                transform.parent = parent;
                transform.position = position;
                transform.rotation = rotation;
            }
            else
            {
                obj = Instantiate(prefab, position, rotation, parent);
                obj.name = objectName;
            }

            return obj;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Release(Component obj, bool inContainer = false)
        {
            this.Release(obj.gameObject, inContainer);
        }

        public void Release(GameObject obj, bool inContainer = false)
        {
            Queue<GameObject> queue = this.gameObjects[obj.name];
            queue.Enqueue(obj);

            if (inContainer)
            {
                obj.transform.SetParent(this.container);
            }
        }
    }
}