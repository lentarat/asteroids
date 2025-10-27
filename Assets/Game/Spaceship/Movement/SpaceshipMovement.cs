using UnityEngine;
using Zenject;

namespace Asteroids.Spaceship.Movement
{
    public class SpaceshipMovement : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private SpaceshipMovementSO _spaceshipMovementSO;
        
        private float _currentAngularVelocity;
        private float _minAngularVelocity = 5f;
        private Vector2 _currentVelocity;
        private ISpaceshipMover _spaceshipMover;

        public void Init(ISpaceshipMover spaceshipMover)
        {
            _spaceshipMover = spaceshipMover;
        }

        private void Update()
        {
            HandleCurrentVelocity();
            HandleCurrentAngularVelocity();
        }

        private void HandleCurrentVelocity()
        {
            float throttleValue = _spaceshipMover.GetThrottleValue();
            if (throttleValue > 0)
            {
                Vector3 velocityOffset =
                    transform.up * _spaceshipMovementSO.Acceleration * Time.deltaTime;
                _currentVelocity += new Vector2(velocityOffset.x, velocityOffset.y);
            }
        }

        private void HandleCurrentAngularVelocity()
        {
            float turnDirectionValue = _spaceshipMover.GetTurnDirectionValue();
            bool isExceedingMinAngularVelocity = ExceedsMinAngularVelocity();

            if (turnDirectionValue == 0f && isExceedingMinAngularVelocity)
            {
                float angularVelocityOffset = -System.MathF.Sign(_currentAngularVelocity) *
                    _spaceshipMovementSO.AngularAcceleration * Time.deltaTime;
                _currentAngularVelocity += angularVelocityOffset;

                isExceedingMinAngularVelocity = ExceedsMinAngularVelocity();
                if (isExceedingMinAngularVelocity == false)
                {
                    _currentAngularVelocity = 0f;
                }
            }
            else
            {
                float angularVelocityOffset = System.MathF.Sign(turnDirectionValue) *
                    _spaceshipMovementSO.AngularAcceleration * Time.deltaTime;

                _currentAngularVelocity += angularVelocityOffset;

                _currentAngularVelocity = Mathf.Clamp(
                    _currentAngularVelocity,
                    -_spaceshipMovementSO.MaxAngularSpeed,
                    _spaceshipMovementSO.MaxAngularSpeed
                    );
            }
        }

        private bool ExceedsMinAngularVelocity()
        {
            bool isExceedingMinAngularVelocity = Mathf.Abs(_currentAngularVelocity) > _minAngularVelocity;
            return isExceedingMinAngularVelocity;
        }

        private void FixedUpdate()
        {
            Move();
            Rotate();
        }

        private void Move()
        {
            Vector2 newPosition = _rigidbody.position + _currentVelocity * Time.fixedDeltaTime;
            _rigidbody.MovePosition(newPosition);
            
        }

        private void Rotate()
        {
            float newRotation = _rigidbody.rotation - _currentAngularVelocity * Time.fixedDeltaTime;
            _rigidbody.MoveRotation(newRotation);
        }
    }
}