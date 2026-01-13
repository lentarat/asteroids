using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Asteroids.Spaceship.Movement
{
    public class SpaceshipMovement : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private SpaceshipMovementSO _spaceshipMovementSO;
        
        private float _currentAngularVelocity;
        private Vector2 _currentVelocity;
        private ISpaceshipMover _spaceshipMover;

        public void InitializeContext(ISpaceshipMover spaceshipMover)
        {
            _spaceshipMover = spaceshipMover;
        }

        public void ResetMovement()
        {
            ResetMovementAsync().Forget();
        }

        private async UniTask ResetMovementAsync()
        {
            await UniTask.WaitForFixedUpdate();

            transform.position = Vector2.zero;
            transform.rotation = Quaternion.identity;
            _currentVelocity = Vector2.zero;
            _currentAngularVelocity = 0;
        }

        private void Update()
        {
            HandleCurrentVelocity();
            HandleCurrentAngularVelocity();
        }

        private void HandleCurrentVelocity()
        {
            float throttleValue = _spaceshipMover.GetThrottleValue();

            if (throttleValue > 0f)
            {
                Vector3 velocityOffset = throttleValue * transform.up *
                    _spaceshipMovementSO.Acceleration * Time.deltaTime;
                _currentVelocity += new Vector2(velocityOffset.x, velocityOffset.y);
                
                bool hasAcceededMaxSpeed = HasAcceededMaxSpeed();
                if (hasAcceededMaxSpeed)
                {
                    _currentVelocity = _currentVelocity.normalized * _spaceshipMovementSO.MaxSpeed;
                }
            }
        }

        private bool HasAcceededMaxSpeed()
        {
            bool hasAcceededMaxSpeed = _currentVelocity.magnitude > _spaceshipMovementSO.MaxSpeed;
            return hasAcceededMaxSpeed;
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