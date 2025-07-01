using UnityEngine;
using Random = UnityEngine.Random;

namespace Game.Engine
{
    public class BulletWeapon : WeaponBase
    {
        [SerializeField]
        private float spreadAngle = 10.0f;

        [SerializeField]
        private Transform firePoint;

        [SerializeField]
        private Bullet bulletPrefab;

        private IBulletSpawner bulletSpawner;
        
        private void Start()
        {
            this.bulletSpawner = ServiceLocator.GetService<IBulletSpawner>();
        }

        protected override void ProcessFire()
        {
            float spreadAngle = Random.Range(-this.spreadAngle, this.spreadAngle);
            
            Vector3 position = this.firePoint.position;
            Quaternion rotation = this.firePoint.rotation * Quaternion.Euler(0, spreadAngle, 0);
            
            this.bulletSpawner.Spawn(this.bulletPrefab, position, rotation);
        }
    }
}