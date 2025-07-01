using UnityEngine;

namespace Game.Engine
{
    public abstract class Bullet : MonoBehaviour
    {
        protected internal abstract bool IsAlive { get; }
        protected internal abstract void OnSpawn();
        protected internal abstract void OnDespawn();
    }
}