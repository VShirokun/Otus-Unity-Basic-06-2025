using System;
using UnityEngine;
using UnityEngine.AI;

namespace Lessons.Lesson_NavMesh
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent _navMeshAgent;
        [SerializeField] private NavMeshLink _navMeshLink;
        
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            
                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    _navMeshAgent.SetDestination(hit.point);
                }
            }

            if (Input.GetAxis("Horizontal") != 0)
            {
                // _navMeshAgent.Move();
            }
        }
    }
}
