using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Engine
{
    [Serializable]
    public class StateMachine : IState
    {
        [ShowInInspector, ReadOnly, HideInEditorMode]
        private IState currentState;
        
        [SerializeReference]
        [ListDrawerSettings(OnBeginListElementGUI = "DrawStateLabel")]
        private List<StateTransition> states = new();
        
        public void OnEnter()
        {
            this.currentState?.OnEnter();
        }

        public void OnUpdate(float deltaTime)
        {
            this.SwitchState();
            this.currentState?.OnUpdate(deltaTime);
        }

        public void OnExit()
        {
            this.currentState?.OnExit();
        }
        
        public void AddTransition(StateTransition transition)
        {
            this.states.Add(transition);
        }

        public void RemoveTransition(StateTransition transition)
        {
            this.states.Remove(transition);
        }

        private void SwitchState()
        {
            for (int i = 0, count = this.states.Count; i < count; i++)
            {
                StateTransition transition = this.states[i];
                if (transition.Condition.IsTrue())
                {
                    this.SwitchState(transition.State);
                    return;
                }
            }
        }
        
        private void SwitchState(IState state)
        {
            if (this.currentState == state)
            {
                return;
            }

            this.currentState?.OnExit();
            this.currentState = state;
            this.currentState?.OnEnter();
        }

#if UNITY_EDITOR
        
        private void DrawStateLabel(int index)
        {
            if (this.states == null)
            {
                return;
            }

            StateTransition transition = this.states[index];
            string label = transition?.State == null 
                ? $"State #{index + 1}" 
                : $"State #{index + 1}: {transition.State.GetType().Name}";
            
            GUILayout.Space(4);
            GUILayout.Label(label);
        }
#endif
    }
}