using UnityEngine;

namespace Lessons.Lesson_NavMesh
{
    public class ObstacleMovementComponent : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _minZ;
        [SerializeField] private float _maxZ;

        private bool _isForwardMoving;
        
        private void Update()
        {
            var direction = _isForwardMoving ? transform.forward : -transform.forward;
            transform.position += direction * _speed * Time.deltaTime;
            
            if (_isForwardMoving && transform.position.z > _maxZ)
            {
                _isForwardMoving = false;
            }
            else if(!_isForwardMoving && transform.position.z < _minZ)
            {
                _isForwardMoving = true;
            }
        }
    }
}