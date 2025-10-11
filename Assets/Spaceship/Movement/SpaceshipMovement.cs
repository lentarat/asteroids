using UnityEngine;

namespace Asteroids.Spaceship.Movement
{
    public class SpaceshipMovement : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private SpaceshipMovementSO _spaceshipMovementSO;
        
        private float _currentAngularSpeed;
        private Vector2 _currentVelocity;
        private ISpaceshipMover _spaceshipMover;

        private void Awake()
        {
            _spaceshipMover = new PlayerSpaceshipMovementInputReader();
        }

        private void Update()
        {
            HandleCurrentVelocity();
            HandleCurrentAngularSpeed();
        }

        private void HandleCurrentVelocity()
        {
            int throttleValue = _spaceshipMover.GetThrottleValue();
            if (throttleValue > 0)
            {
                Vector3 velocityOffset = transform.up * _spaceshipMovementSO.Acceleration * Time.deltaTime;
                _currentVelocity += new Vector2(velocityOffset.x, velocityOffset.y);
            }
        }

        private void HandleCurrentAngularSpeed()
        { 
        
        }

        private void FixedUpdate()
        {
            Move();
        }

        private void Move()
        {
            float newRotation = _rigidbody.rotation + _currentAngularSpeed * Time.fixedDeltaTime;
            Vector2 newPosition = _rigidbody.position + _currentVelocity * Time.fixedDeltaTime;
            _rigidbody.MovePosition(newPosition);
            _rigidbody.MoveRotation(newRotation);
        }
    }
}