// using JetBrains.Annotations;
// using UnityEngine;
//
// namespace Game.Engine
// {
//     [RequireComponent(typeof(Animator))]
//     public sealed class FireAnimationEventListener : MonoBehaviour
//     {
//         private const string FIRE_EVENT = "fire_event";
//
//         [SerializeField]
//         private WeaponComponent weaponComponent;
//
//         [UsedImplicitly]
//         private void ReceiveEvent(string message)
//         {
//             if (message == FIRE_EVENT)
//             {
//                 this.weaponComponent.Fire();
//             }
//         }
//     }
// }