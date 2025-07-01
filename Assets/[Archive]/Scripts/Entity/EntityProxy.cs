using UnityEngine;

namespace Game.Engine
{
    public sealed class EntityProxy : EntityBase
    {
        [SerializeField]
        private EntityBase entity;
        
        public override T Get<T>()
        {
            return this.entity.Get<T>();
        }
    }
}