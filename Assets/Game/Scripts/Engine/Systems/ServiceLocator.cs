using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game.Engine
{
    [DefaultExecutionOrder(-10000)]
    public sealed class ServiceLocator : MonoBehaviour
    {
        private static ServiceLocator instance;
        
        [SerializeField]
        private MonoBehaviour[] initialServices;

        private List<object> services;

        private void Awake()
        {
            instance = this;
            this.services = new List<object>(this.initialServices);
        }

        public static T GetService<T>()
        {
            foreach (var service in instance.services)
            {
                if (service is T result)
                {
                    return result;
                }
            }

            throw new Exception($"Service of type {typeof(T).Name} is not found");
        }
        
        public static T[] GetServices<T>()
        {
            var result = new HashSet<T>();
            
            foreach (var service in instance.services)
            {
                if (service is T tService)
                {
                    result.Add(tService);
                }
            }

            return result.ToArray();
        }
        
        public static void AddService(object service)
        {
            instance.services.Add(service);
        }

        public static void RemoveService(object service)
        {
            instance.services.Remove(service);
        }
    }
}