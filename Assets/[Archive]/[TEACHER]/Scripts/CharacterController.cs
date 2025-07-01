// using System;
// using InputModule;
// using JetBrains.Annotations;
// using UnityEngine;
// using Random = UnityEngine.Random;
//
// public sealed class CharacterController : MonoBehaviour
// {
//     [Header("Animator")]
//     [SerializeField]
//     private Animator animator;
//
//     [Header("Rotation")]
//     [SerializeField]
//     private Transform rotationTransform;
//
//     [SerializeField]
//     private float rotationTime;
//
//     [Header("Fire")]
//     [SerializeField]
//     private GameObject bulletPrefab;
//
//     [SerializeField]
//     private Transform firePoint;
//
//     [SerializeField]
//     private ParticleSystem fireVFX;
//
//     [SerializeField]
//     private AudioSource audioSource;
//     
//     private JoystickInput joystick;
//
//     private void Start()
//     {
//         this.joystick = FindObjectOfType<JoystickInput>();
//     }
//
//     private void Update()
//     {
//         this.UpdateMove();
//         this.UpdateFire();
//     }
//
//     private void UpdateMove()
//     {
//         //Если нажимаем на стрелочку вперед!
//         int animState = 0;
//         Vector3 direction = new Vector3(this.joystick.CurrentDirection.x, 0, this.joystick.CurrentDirection.y);
//
//         // if (Input.GetKey(KeyCode.UpArrow))
//         // {
//         //     direction.z = 1;
//         //     animState = 1;
//         // }
//         // else if (Input.GetKey(KeyCode.DownArrow))
//         // {
//         //     direction.z = -1;
//         //     animState = 1;
//         // }
//         //
//         // if (Input.GetKey(KeyCode.LeftArrow))
//         // {
//         //     direction.x = -1;
//         //     animState = 1;
//         // }
//         // else if (Input.GetKey(KeyCode.RightArrow))
//         // {
//         //     direction.x = 1;
//         //     animState = 1;
//         // }
//
//         if (direction != Vector3.zero)
//         {
//             var targetRotation = Quaternion.LookRotation(direction);
//             this.rotationTransform.rotation = Quaternion.Slerp(
//                 this.rotationTransform.rotation,
//                 targetRotation,
//                 this.rotationTime * Time.deltaTime
//             );
//             
//             this.animator.SetInteger("State", 1);
//         }
//         else
//         {
//             this.animator.SetInteger("State", 0);
//         }
//
//     }
//
//     private void UpdateFire()
//     {
//         var layerIndex = this.animator.GetLayerIndex("FireLayer");
//
//         if (Input.GetKey(KeyCode.Space))
//         {
//             this.animator.SetLayerWeight(layerIndex, 1);
//         }
//         else
//         {
//             this.animator.SetLayerWeight(layerIndex, 0);
//         }
//     }
//
//     [UsedImplicitly]
//     private void FireAnimEvent()
//     {
//         Instantiate(this.bulletPrefab, this.firePoint.position, this.firePoint.rotation, null);
//         this.fireVFX.Play(true);
//         this.audioSource.pitch = Random.Range(1, 1.5f);
//         this.audioSource.Play();
//     }
// }