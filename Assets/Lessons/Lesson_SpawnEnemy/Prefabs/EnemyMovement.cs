using UnityEngine;

namespace Lessons.Lesson_SpawnEnemy
{
    public class EnemyMovement : MonoBehaviour
    {
        [SerializeField] private float _speed = 0.5f;

        private void Update()
        {
            transform.position += transform.forward * _speed * Time.deltaTime;
        }
    }
}
