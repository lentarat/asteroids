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
            float targetAngularVelocity = turnDirectionValue * _spaceshipMovementSO.MaxAngularSpeed;

            _currentAngularVelocity = Mathf.MoveTowards(
                _currentAngularVelocity,
                targetAngularVelocity,
                _spaceshipMovementSO.AngularAcceleration * Time.deltaTime
                );
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