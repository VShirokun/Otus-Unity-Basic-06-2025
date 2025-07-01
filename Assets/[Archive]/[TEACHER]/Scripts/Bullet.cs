// using System.Collections;
// using UnityEngine;
//
// public sealed class Bullet : MonoBehaviour
// {
//     [SerializeField]
//     private new Rigidbody rigidbody;
//
//     [SerializeField]
//     private float speed = 10;
//
//     private IEnumerator Start()
//     {
//         this.rigidbody.velocity = this.transform.forward * this.speed;
//         yield return new WaitForSeconds(2);
//         Destroy(this.gameObject);
//     }
//
//     private void OnCollisionEnter(Collision collision)
//     {
//         if (collision.collider.TryGetComponent(out Zombie enemy))
//         {
//             var position = this.transform.position;
//             var direction = (position - enemy.transform.position).normalized;
//             enemy.TakeDamage(position, direction);
//             Destroy(this.gameObject);
//         }
//     }
// }