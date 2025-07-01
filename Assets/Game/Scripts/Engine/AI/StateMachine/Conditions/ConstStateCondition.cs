using System;
using UnityEngine;

namespace Game.Engine
{
    [Serializable]
    public sealed class ConstStateCondition : IStateCondition
    {
        [SerializeField]
        private bool isTrue;
        
        public bool IsTrue()
        {
            return this.isTrue;
        }
    }
}