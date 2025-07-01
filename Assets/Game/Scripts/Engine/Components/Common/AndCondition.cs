using System;
using System.Collections.Generic;

namespace Game.Engine
{
    public sealed class AndCondition
    {
        private readonly List<Func<bool>> conditions = new();

        public void Add(Func<bool> condition)
        {
            this.conditions.Add(condition);
        }

        public void Remove(Func<bool> condition)
        {
            this.conditions.Remove(condition);
        }
        
        public bool IsTrue()
        {
            for (int i = 0, count = this.conditions.Count; i < count; i++)
            {
                Func<bool> condition = this.conditions[i];
                if (!condition.Invoke())
                {
                    return false;
                }
            }

            return true;
        }
    }
}