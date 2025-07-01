using System;
using UnityEngine;

namespace Game.Lessons.Optimization
{
    public class MonoFoo : MonoBehaviour
    {
        // [SerializeField] private TYPE _type;
        
        private void Start()
        {
            var buildings = FindObjectsOfType<Building>();
            var rb = GetComponent<Rigidbody>();
            // var enemyController = Fin
        }

        private void Update()
        {
            var rb = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            var rb = GetComponent<Rigidbody>();
        }

        private void OnTriggerStay(Collider other)
        {
            
        }

        private void OnTriggerEnter(Collider other)
        {
            
        }
    }

    internal class Building : MonoBehaviour
    {
    }

    public class Foo
    {
        public void ChangeSettings()
        {
            // QualitySettings.SetQualityLevel();
        }
    }
}