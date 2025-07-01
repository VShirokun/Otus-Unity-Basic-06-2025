using System;
using NTC.Pool;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game.Lessons.Optimization
{
    public class InstancingExample : MonoBehaviour
    {
        public Mesh Mesh;               
        public Material Material;       
        public int InstanceCount = 100; 

        [SerializeField] private LayerMask _layerMask;
        
        private Matrix4x4[] _matrices;  

        void Start()
        {
            // Включаем instancing в материале (если забыли в Inspector)
            Material.enableInstancing = true;

            _matrices = new Matrix4x4[InstanceCount];
            for (int i = 0; i < InstanceCount; i++)
            {
                // раскидаем кубы в радиусе 10
                Vector3 pos = Random.insideUnitSphere * 10f;
                Quaternion rot = Quaternion.Euler(Random.value * 360f, Random.value * 360f, 0f);
                Vector3 scale = Vector3.one * Random.Range(0.5f, 1.5f);
                _matrices[i] = Matrix4x4.TRS(pos, rot, scale);
            }
        }

        void Update()
        {
            // Один Draw Call для всех instanceCount
            Graphics.DrawMeshInstanced(Mesh, 0, Material, _matrices);
            // NightPool.Spawn();
        }

        private void FixedUpdate()
        {
            var colliders = new Collider[InstanceCount];
            var size = Physics.OverlapBoxNonAlloc(transform.position,
                Vector3.one * 10f, colliders, Quaternion.identity, _layerMask);
        }
    }
}