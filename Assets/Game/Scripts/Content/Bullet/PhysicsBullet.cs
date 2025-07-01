using Game.Engine;
using UnityEngine;
using UnityEngine.Events;

// ReSharper disable ConvertToAutoPropertyWithPrivateSetter
// ReSharper disable ArgumentsStyleOther

namespace Game.Content
{
    [RequireComponent(typeof(DealDamageAction), typeof(LifetimeComponent), typeof(Rigidbody))]
    public sealed class PhysicsBullet : Bullet
    {
        [SerializeField]
        private float speed = 45f;

        [SerializeField]
        private int damage = 1;

        [SerializeField]
        private UnityEvent onSpawned;

        [SerializeField]
        private UnityEvent onDespawned;

        private DealDamageAction damageAction;
        private LifetimeComponent lifetimeComponent;
        private new Rigidbody rigidbody;

        private bool collided;

        protected override bool IsAlive
        {
            get { return !this.collided && this.lifetimeComponent.CurrentTime > 0; }
        }

        private void Awake()
        {
            this.damageAction = this.GetComponent<DealDamageAction>();
            this.lifetimeComponent = this.GetComponent<LifetimeComponent>();
            this.rigidbody = this.GetComponent<Rigidbody>();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (this.collided)
            {
                return;
            }

            if (this.damageAction.DealDamage(collision.collider, this.damage))
            {
                this.collided = true;
            }
        }

        protected override void OnSpawn()
        {
            this.collided = false;
            this.rigidbody.velocity = this.transform.forward * this.speed;
            this.lifetimeComponent.Reset();
            this.onSpawned?.Invoke();
        }

        protected override void OnDespawn()
        {
            this.onDespawned?.Invoke();
        }
    }
}