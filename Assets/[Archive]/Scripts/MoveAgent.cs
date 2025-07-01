// using System.Collections;
// using System.Collections.Generic;
// using Sirenix.OdinInspector;
// using Sirenix.Serialization;
// using UnityEngine;
// using UnityEngine.AI;
// // ReSharper disable IteratorNeverReturns
//
// namespace Game.Engine
// {
//     public sealed class MoveAgent : SerializedMonoBehaviour
//     {
//         private static readonly RaycastHit[] buffer = new RaycastHit[32]; 
//         
//         public delegate void MoveTowardsAction(Vector3 moveDirection);
//
//         [SerializeField]
//         private Transform sourceTransform;
//
//         [ShowInInspector, ReadOnly, Space]
//         private Vector3 destination = new(1000000, 0, 10000000);
//
//         [SerializeField]
//         private float stoppingDistance = 0.5f;
//
//         [ShowInInspector, ReadOnly]
//         private Vector3[] path = new Vector3[32];
//
//         [ShowInInspector, ReadOnly, Space]
//         private int pathSize;
//
//         [ShowInInspector, ReadOnly]
//         private int pathPointer;
//
//         private Coroutine moveCoroutine;
//
//         [ShowInInspector, ReadOnly, PropertySpace]
//         public bool IsPlaying => this.moveCoroutine != null;
//
//         [SerializeField, HideInPlayMode]
//         private float updatePeriod = 0.1f;
//
//         [OdinSerialize]
//         private MoveTowardsAction moveAction;
//
//         private NavMeshPath navMeshPath;
//         private WaitForSeconds period;
//
//         [SerializeField, Space]
//         private bool obstacleAvoidance = true;
//
//         [SerializeField, ShowIf("obstacleAvoidance")]
//         private float avoidanceDistance = 1.0f;
//
//         [SerializeField, ShowIf("obstacleAvoidance")]
//         private LayerMask avoidanceMask;
//
//         [SerializeField, ShowIf("obstacleAvoidance")]
//         private List<Collider> myColliders;
//
//         [SerializeField, ShowIf("obstacleAvoidance")]
//         private float heightOffset = 1;
//
//         private void Awake()
//         {
//             this.navMeshPath = new NavMeshPath();
//             this.period = new WaitForSeconds(this.updatePeriod);
//         }
//
//         public void SetTransform(Transform transform)
//         {
//             this.sourceTransform = transform;
//         }
//
//         [Button]
//         public void SetDestination(Vector3 destination)
//         {
//             if (this.destination != destination)
//             {
//                 this.RecalculatePath(destination);
//                 this.destination = destination;
//             }
//         }
//
//         [Button]
//         public void SetStoppingDistance(float stoppingDistance)
//         {
//             this.stoppingDistance = stoppingDistance;
//         }
//
//         [Button]
//         public void SetMoveAction(MoveTowardsAction moveAction)
//         {
//             this.moveAction = moveAction;
//         }
//
//         public void MoveOneFrame()
//         {
//             if (this.pathPointer == -1)
//             {
//                 this.moveAction?.Invoke(Vector3.zero);
//                 return;
//             }
//
//             if (this.pathPointer >= this.pathSize)
//             {
//                 this.moveAction?.Invoke(Vector3.zero);
//                 return;
//             }
//
//             Vector3 currentPosition = this.sourceTransform.position;
//             Vector3 targetPosition = this.path[this.pathPointer];
//             Vector3 delta = targetPosition - currentPosition;
//             delta.y = 0;
//
//             if (delta.sqrMagnitude <= this.stoppingDistance * this.stoppingDistance)
//             {
//                 this.pathPointer++;
//                 return;
//             }
//
//
//             Vector3 direction = delta.normalized;
//             if (this.obstacleAvoidance)
//             {
//                 Ray ray = new Ray(currentPosition + new Vector3(0, heightOffset, 0), direction);
//                 var size = Physics.RaycastNonAlloc(ray, buffer, this.avoidanceDistance, this.avoidanceMask);
//
//                 for (int i = 0; i < size; i++)
//                 {
//                     RaycastHit hit = buffer[i];
//                     if (!this.myColliders.Contains(hit.collider) )
//                     {
//                         direction = Vector3.Cross(hit.normal, Vector3.up);
//                         break;
//                     }
//                 }
//             }
//
//             this.moveAction?.Invoke(direction);
//         }
//
//         public void SetAsReached()
//         {
//             this.pathPointer = -1;
//         }
//         
//         [Button]
//         public void MoveAsync()
//         {
//             this.moveCoroutine ??= this.StartCoroutine(this.MoveRoutine());
//         }
//
//         [Button]
//         public void Stop()
//         {
//             if (this.moveCoroutine != null)
//             {
//                 this.StopCoroutine(this.moveCoroutine);
//             }
//
//             this.moveCoroutine = null;
//             this.moveAction?.Invoke(Vector3.zero);
//         }
//
//         private IEnumerator MoveRoutine()
//         {
//             while (true)
//             {
//                 this.MoveOneFrame();
//                 yield return this.period;
//             }
//         }
//
//         [Button]
//         public bool IsReached()
//         {
//             Vector3 delta = this.destination - this.sourceTransform.position;
//             return delta.sqrMagnitude <= this.stoppingDistance * this.stoppingDistance;
//         }
//
//         private void RecalculatePath(Vector3 destination)
//         {
//             Vector3 myPosition = this.sourceTransform.position;
//             
//             Calc:
//             if (NavMesh.CalculatePath(myPosition, destination, NavMesh.AllAreas, this.navMeshPath))
//             {
//                 this.pathSize = this.navMeshPath.GetCornersNonAlloc(this.path);
//                 this.pathPointer = 1; //Потому что 0, это точка, где мы стоим! 
//             }
//             else
//             {
//                 myPosition += Random.onUnitSphere * 1.0f;
//                 myPosition.y = 0;
//                 goto Calc;
//             }
//             
//             
//             // else if (NavMesh.SamplePosition(myPosition, out NavMeshHit hit, 10.0f, NavMesh.AllAreas))
//             // {
//             //     myPosition = hit.position;
//             //     goto Calc;
//             // }
//
//
//
//             //
//             // else
//             // {
//             //     this.pathSize = 0;
//             //     this.pathPointer = -1;
//             // }
//         }
//     }
// }