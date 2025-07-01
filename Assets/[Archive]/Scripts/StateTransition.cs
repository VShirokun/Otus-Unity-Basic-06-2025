// using System;
//
// namespace Game.Engine
// {
//     public sealed class StateTransition : IStateTransition
//     {
//         private readonly State state;
//         private readonly Func<bool> condition;
//
//         public StateTransition(State state, Func<bool> condition)
//         {
//             this.state = state;
//             this.condition = condition;
//         }
//
//         public bool IsConditionPerforms(out State state)
//         {
//             state = this.state;
//             return this.condition.Invoke();
//         }
//     }
// }