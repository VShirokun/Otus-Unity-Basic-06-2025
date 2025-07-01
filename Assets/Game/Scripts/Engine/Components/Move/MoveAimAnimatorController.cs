using UnityEngine;

namespace Game.Engine
{
    [RequireComponent(typeof(Animator))]
    public sealed class MoveAimAnimatorController : MonoBehaviour
    {
        private const float maxSpeed = 1000;

        private static readonly int IsAiming = Animator.StringToHash("IsAiming");
        public static readonly int AimX = Animator.StringToHash("AimX");
        public static readonly int AimZ = Animator.StringToHash("AimZ");

        [SerializeField]
        private MoveComponent moveComponent;

        [SerializeField]
        private AimComponent aimComponent;

        [SerializeField]
        private float smoothTime = 0.2f;

        private Animator animator;

        private Vector3 _currentVector;
        private Vector3 _smoothVelocity;

        private void Awake()
        {
            this.animator = this.GetComponent<Animator>();
        }

        private void FixedUpdate()
        {
            Vector3 aimDirection = this.aimComponent.GetDirection();
            aimDirection.y = 0;

            if (aimDirection.sqrMagnitude <= 0)
            {
                this.animator.SetBool(IsAiming, false);
                return;
            }

            Vector3 moveDirection = this.moveComponent.GetDirection();
            moveDirection.y = 0;

            Quaternion quaternion = Quaternion.FromToRotation(aimDirection, moveDirection);
            Vector3 targetVector = CalcTargetVector(quaternion.eulerAngles.y);

            _currentVector = Vector3.SmoothDamp(
                _currentVector,
                targetVector,
                ref _smoothVelocity,
                smoothTime,
                maxSpeed,
                Time.fixedDeltaTime
            );

            this.animator.SetFloat(AimX, _currentVector.x);
            this.animator.SetFloat(AimZ, _currentVector.z);
            this.animator.SetBool(IsAiming, true);
        }

        private static Vector3 CalcTargetVector(float angleInDegrees)
        {
            if (angleInDegrees is >= 0 and < 22.5f || angleInDegrees >= 337.5)
            {
                return new Vector3(0, 0, 1);
            }

            if (angleInDegrees is >= 22.5f and < 67.5f)
            {
                return new Vector3(1, 0, 1);
            }

            if (angleInDegrees is >= 67.5f and < 112.5f)
            {
                return new Vector3(1, 0, 0);
            }

            if (angleInDegrees is >= 112.5f and < 157.5f)
            {
                return new Vector3(1, 0, -1);
            }

            if (angleInDegrees is >= 157.5f and < 202.5f)
            {
                return new Vector3(0, 0, -1);
            }

            if (angleInDegrees is >= 202.5f and < 247.5f)
            {
                return new Vector3(-1, 0, -1);
            }

            if (angleInDegrees is >= 247.5f and < 292.5f)
            {
                return new Vector3(-1, 0, 0);
            }

            if (angleInDegrees is >= 292.5f and < 337.5f)
            {
                return new Vector3(-1, 0, 1);
            }

            return Vector3.zero;
        }
    }
}