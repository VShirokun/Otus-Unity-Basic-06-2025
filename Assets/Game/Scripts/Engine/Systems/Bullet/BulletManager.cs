using System.Collections.Generic;
using UnityEngine;

namespace Game.Engine
{
    internal sealed class BulletManager : MonoBehaviour, IBulletSpawner
    {
        private static readonly List<Bullet> cache = new();

        [SerializeField]
        private Transform container;

        private GameObjectPool pool;

        private readonly HashSet<Bullet> sceneBullets = new();

        private void Start()
        {
            this.pool = ServiceLocator.GetService<GameObjectPool>();
        }

        private void FixedUpdate()
        {
            cache.Clear();
            cache.AddRange(this.sceneBullets);

            for (int i = 0, count = cache.Count; i < count; i++)
            {
                Bullet bullet = cache[i];
                if (bullet.IsAlive)
                {
                    continue;
                }

                this.Despawn(bullet);
            }
        }

        void IBulletSpawner.Spawn(Bullet prefab, Vector3 position, Quaternion rotation)
        {
            Bullet bullet = this.pool.Get(prefab, position, rotation, this.container);
            bullet.gameObject.SetActive(true);
            bullet.OnSpawn();
            this.sceneBullets.Add(bullet);
        }

        private void Despawn(Bullet bullet)
        {
            bullet.OnDespawn();
            bullet.gameObject.SetActive(false);
            this.sceneBullets.Remove(bullet);
            this.pool.Release(bullet.gameObject);
        }
    }
}