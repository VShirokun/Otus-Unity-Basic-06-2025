using System.Collections;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.AI;
// ReSharper disable IteratorNeverReturns

namespace Game.Engine
{
    [RequireComponent(typeof(NavMeshAgent))]
    public sealed class MoveAgent : MonoBehaviour
    {
        [SerializeField, Space]
        private Transform originTransfom;

        private NavMeshAgent navMeshAgent;

        [SerializeField, Space]
        private float distanceThreshold = 0.5f;

        [SerializeField, HideInPlayMode]
        private float updatePeriod = 0.1f;

        private Vector3 _currentMoveDirection;
        private Coroutine _currentCoroutine;
        
        private void Awake()
        {
            this.navMeshAgent = this.GetComponent<NavMeshAgent>();
            this.navMeshAgent.enabled = false;
        }

        public void Play()
        {
            this.navMeshAgent.enabled = true;
            _currentCoroutine ??= this.StartCoroutine(this.Loop());
        }

        public void SetDestination(Vector3 destination)
        {
            this.navMeshAgent.destination = destination;
        }

        public Vector3 GetMoveDirection()
        {
            return _currentMoveDirection;
        }

        private IEnumerator Loop()
        {
            var period = new WaitForSeconds(this.updatePeriod);
            while (true)
            {
                yield return period;

                Vector3 nextPosition = this.navMeshAgent.nextPosition;
                Vector3 myPosition = this.originTransfom.position;
                Vector3 delta = nextPosition - myPosition;
                this.navMeshAgent.isStopped = delta.magnitude > distanceThreshold;
                
                _currentMoveDirection = delta.normalized;
            }
        }

        public void Stop()
        {
            this.navMeshAgent.enabled = false;
            
            if (_currentCoroutine != null)
            {
                this.StopCoroutine(_currentCoroutine);
                _currentCoroutine = null;
            }
        }
    }
}

//
// public Vector3 CalcMoveDirection(Vector3 destination)
// {
//     Vector3 nextPosition = this.navMeshAgent.nextPosition;
//     Vector3 delta = nextPosition - myPosition;
//     this.navMeshAgent.isStopped = delta.magnitude > distanceThreshold;
//
//     this.zombie.GetComponent<MoveComponent>().SetDirection(delta.normalized);
//
//     Debug.Log($"DESIRED VELOCITY {this.navMeshAgent.desiredVelocity}");
//     // _moveComponent.SetDirection(this.moveAgent.desiredVelocity.normalized);
// }

// public void StopMove()
// {
//     _moveComponent.SetDirection(Vector3.zero);
//     this.navMeshAgent.isStopped = true;
//
// }