using UnityEngine;

namespace Game.Engine
{
    public sealed class Entity : EntityBase
    {
        [SerializeField]
        private MonoBehaviour[] components;

        public override T Get<T>() where T : class 
        {
            for (int i = 0, count = this.components.Length; i < count; i++)
            {
                if (this.components[i] is T result)
                {
                    return result;
                }
            }

            return default;
        }
    }
}