using System;
using UnityEngine;

namespace Game.Engine
{
    [Serializable]
    public sealed class StateTransition
    {
        public IState State => this.state;
        public IStateCondition Condition => this.condition;

        [SerializeReference]
        private IState state;

        [SerializeReference]
        private IStateCondition condition;

        public StateTransition(IState state, IStateCondition condition)
        {
            this.state = state;
            this.condition = condition;
        }
    }
}