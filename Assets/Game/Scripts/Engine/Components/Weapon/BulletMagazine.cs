using System;
using UnityEngine;

namespace Game.Engine
{
    public sealed class BulletMagazine : MonoBehaviour
    {
        public event Action OnStateChanged;
        
        [SerializeField, Min(0)]
        private int bulletCount = 10;

        public int GetBulletCount()
        {
            return this.bulletCount;
        }

        public bool HasBullets()
        {
            return this.bulletCount > 0;
        }

        public void AddBullets(int charges)
        {
            this.bulletCount += charges;
            this.OnStateChanged?.Invoke();
        }

        public void SpendBullet()
        {
            if (this.bulletCount > 0)
            {
                this.bulletCount--;
                this.OnStateChanged?.Invoke();
            }
        }
    }
}