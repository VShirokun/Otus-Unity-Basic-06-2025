using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Engine
{
    public sealed class LifeComponent : MonoBehaviour
    {
        public delegate void TakeDamageDelegate(GameObject source, int damage);

        public event TakeDamageDelegate OnDeath;
        public event TakeDamageDelegate OnDamageTaken;
        public event Action OnStateChanged;

        [SerializeField, Min(0)]
        private int maxHitPoints = 10;

        [SerializeField, Min(0)]
        private int hitPoints = 3;

        [Button]
        public void TakeDamage(GameObject source, int damage)
        {
            if (this.hitPoints == 0)
            {
                return;
            }

            this.hitPoints -= damage;

            if (this.hitPoints > 0)
            {
                this.OnDamageTaken?.Invoke(source, damage);
            }
            else
            {
                this.OnDeath?.Invoke(source, damage);
            }
            
            this.OnStateChanged?.Invoke();
        }

        public void RestoreHitPoints(int healthPoints)
        {
            this.hitPoints = Mathf.Min(this.hitPoints + healthPoints, this.maxHitPoints);
            this.OnStateChanged?.Invoke();
        }

        public bool IsAlive()
        {
            return this.hitPoints > 0;
        }

        public bool IsHealthFull()
        {
            return this.hitPoints == this.maxHitPoints;
        }

        public float GetHealthPercent()
        {
            return (float) this.hitPoints / this.maxHitPoints;
        }

        public int GetCurrentHitPoints()
        {
            return this.hitPoints;
        }
    }
}