// using UnityEngine;
//
// namespace Game.Engine
// {
//     [RequireComponent(typeof(Animator))]
//     public sealed class AttackAnimatorComponent : MonoBehaviour
//     {
//         private const string FIRE_LAYER = "Fire Layer";
//
//         [SerializeField]
//         private AttackComponent attackComponent;
//         
//         private Animator animator;
//
//         private int fireLayer;
//
//         private void Awake()
//         {
//             this.animator = this.GetComponent<Animator>();
//             this.fireLayer = this.animator.GetLayerIndex(FIRE_LAYER);
//         }
//
//         private void Update()
//         {
//             int layerWeight = attackComponent.IsAttacking() ? 1 : 0;
//             this.animator.SetLayerWeight(this.fireLayer, layerWeight);
//         }
//     }
// }