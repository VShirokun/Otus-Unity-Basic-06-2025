using UnityEngine;

namespace Game.Engine
{
    public interface IBulletSpawner
    {
        void Spawn(Bullet prefab, Vector3 position, Quaternion rotation);
    }
}