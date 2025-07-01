using UnityEngine;

namespace Game.Engine
{
    public abstract class EntityBase : MonoBehaviour, IEntity
    {
        public abstract T Get<T>() where T : class;
    }
}