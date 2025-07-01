// using UnityEngine;
//
// public sealed class Zombie : MonoBehaviour
// {
//     [SerializeField]
//     private Animator animator;
//
//     [SerializeField]
//     private int hitPoints = 3;
//
//     [SerializeField]
//     private float stoppingDistance = 1.5f;
//     
//     [SerializeField]
//     private float rotationTime;
//
//     [SerializeField]
//     private GameObject target;
//
//     [SerializeField]
//     private AudioSource audioSource;
//
//     [SerializeField]
//     private ParticleSystem bloodVFX;
//
//     public void TakeDamage(Vector3 position, Vector3 direction)
//     {
//         if (this.hitPoints <= 0)
//         {
//             return;
//         }
//         
//         this.hitPoints--;
//         
//         this.audioSource.pitch = Random.Range(1, 1.5f);
//         this.audioSource.Play();
//
//         if (this.hitPoints > 0)
//         {
//             this.animator.SetTrigger("TakeDamage");
//         }
//         else
//         {
//             this.animator.SetTrigger("Death");
//             this.enabled = false;
//             this.GetComponent<Collider>().enabled = false;
//         }
//
//         bloodVFX.transform.forward = direction;
//         bloodVFX.transform.position = position;
//         bloodVFX.Play(this);
//     }
//
//     private void FixedUpdate()
//     {
//         this.AttackTarget();
//     }
//
//     private void AttackTarget()
//     {
//         
//         if (this.target == null)
//         {
//             this.animator.SetInteger("State", 0); //Idle
//             return;
//         }
//
//         Vector3 targetPosition = this.target.transform.position;
//         Vector3 myPosition = this.transform.position;
//         Vector3 delta = targetPosition - myPosition;
//
//         if (delta.magnitude > this.stoppingDistance)
//         {
//             this.animator.SetInteger("State", 1); //Move
//         }
//         else
//         {
//             this.animator.SetInteger("State", 2); //Attack
//         }
//         
//         this.RotateTowards(delta.normalized);
//     }
//
//     private void RotateTowards(Vector3 direction)
//     {
//         if (direction != Vector3.zero)
//         {
//             var targetRotation = Quaternion.LookRotation(direction);
//             this.transform.rotation = Quaternion.Slerp(
//                 this.transform.rotation, targetRotation, this.rotationTime * Time.deltaTime
//             );
//         }
//     }
// }
//
