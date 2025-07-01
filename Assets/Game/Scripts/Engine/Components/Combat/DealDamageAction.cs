using System;
using UnityEngine;

namespace Game.Engine
{
    public sealed class DealDamageAction : MonoBehaviour
    {
        public event Action<GameObject> OnDealDamage;

        [SerializeField]
        private GameObject source;
        
        public bool DealDamage(Collider collider, int damage)
        {
            LifeComponent lifeComponent = collider.GetComponentInParent<LifeComponent>();
            if (lifeComponent != null)
            {
                lifeComponent.TakeDamage(this.source, damage);
                this.OnDealDamage?.Invoke(collider.gameObject);
                return true;
            }

            return false;
        }

        public bool DealDamage(GameObject gameObject, int damage)
        {
            LifeComponent lifeComponent = gameObject.GetComponentInParent<LifeComponent>();
            if (lifeComponent != null)
            {
                lifeComponent.TakeDamage(this.source, damage);
                this.OnDealDamage?.Invoke(gameObject);
                return true;
            }

            return false;
        }

        private void Reset()
        {
            this.source = this.gameObject;
        }
    }
}