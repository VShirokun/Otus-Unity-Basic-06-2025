using Game.Engine;
using UnityEngine;
using UnityEngine.AI;

namespace Game.Content
{
    public sealed class ZombieAI : MonoBehaviour
    {
        [SerializeField]
        private Zombie zombie;
 
        [SerializeField]
        private StateMachine stateMachine;

        [SerializeField]
        private NavMeshAgent moveAgent;

        private void Awake()
        {
            this.moveAgent.updatePosition = false;
            this.moveAgent.updateRotation = false;
        }

        private void OnEnable()
        {
            this.zombie.GetComponent<LifeComponent>().OnDeath += this.OnDeath;
            this.stateMachine.OnEnter();
        }
        
        private void OnDisable()
        {
            this.zombie.GetComponent<LifeComponent>().OnDeath -= this.OnDeath;
            this.stateMachine.OnExit();
        }
        
        private void FixedUpdate()
        {
            this.stateMachine.OnUpdate(Time.fixedDeltaTime);
        }
        
        private void OnDeath(GameObject source, int damage)
        {
            this.enabled = false;
        }
        
        
    }
}

// private IEnumerator Start()
// {
//     while (true)
//     {
//         yield return new WaitForSeconds(0.2f);
//         this.moveAgent.pos
//         this.moveAgent.Warp();
//     }
// }


// private void Awake()
// {
//     //Configure move agent:
//     // var moveComponent = this.zombie.GetComponent<MoveComponent>();
//             
//     // this.moveAgent.SetMoveAction(moveComponent.SetDirection);
//     // this.moveAgent.SetTransform(this.zombie.transform);
//     // this.moveAgent.SetStoppingDistance(STOPPING_DISTANCE);
// }


//  [SerializeField]
// private Transform sourceTransform;
//
// [SerializeField]
// private LifeComponent lifeComponent;
//
// [SerializeField]
// private MoveComponent moveComponent;
//
// [SerializeField]
// private AttackComponent attackComponent;
//
// [SerializeField]
// private RotateComponent rotateComponent;
//
//
// [SerializeField, Space]
// private float attackDistance = 1.5f;
//
// private TargetComponent targetComponent;
//
// private MoveAgent moveAgent;
//
// private void Awake()
// {
//     this.targetComponent = this.GetComponent<TargetComponent>();
//     this.moveAgent = this.GetComponent<MoveAgent>();
// }
//
// private void OnEnable()
// {
//     this.lifeComponent.OnDeath += this.OnDeath;
// }
//
// private void OnDisable()
// {
//     this.lifeComponent.OnDeath -= this.OnDeath;
// }
//
// private void OnDeath(GameObject source, int damage)
// {
//     this.enabled = false;
// }