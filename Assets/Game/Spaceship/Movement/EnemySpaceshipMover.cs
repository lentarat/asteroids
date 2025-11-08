using Asteroids.Spaceship.Movement;
using TMPro.EditorUtilities;
using UnityEngine;

namespace Asteroids.Spaceship.Movement
{
    public class EnemySpaceshipMover : ISpaceshipMover
    {
        private float _followPlayerRadius = 2f;
        private float _changeDestinationInterval = 5f;
        private float _maxSpeedSqr = 1f;
        private Vector3 _currentDestinationPosition;
        private Rigidbody2D _rigidbody;
        private Rigidbody2D _playerRigidbody;

        public EnemySpaceshipMover(
            Rigidbody2D enemyRigidbody,
            Rigidbody2D playerRigidbody
            )
        {
            _rigidbody = enemyRigidbody;
            _playerRigidbody = playerRigidbody;
        }

        float ISpaceshipMover.GetThrottleValue()
        {
            return 0f;
        }

        float ISpaceshipMover.GetTurnDirectionValue()
        {
            bool hasAccededMaxSpeed = HasAccededMaxSpeed();

            if(hasAccededMaxSpeed == false)
            {
                Vector3 directionToDestination = GetDirectionToDestination();
                return 1f;
            }

            Vector3 enemyToPlayerVector = (_playerRigidbody.position - _rigidbody.position).normalized;
            float signedAngle = Vector2.SignedAngle(enemyToPlayerVector, _rigidbody.transform.up);

            //Debug.Log(Vector2.Dot(enemyToPlayerVector, _transform.up));

             //   return 0f;
            if (signedAngle > 0)
            {
                return 1f;
            }
            else
            {
                return -1f;
            }
        }

        private Vector3 GetDirectionToDestination()
        {
            return default;
        }

        private bool HasAccededMaxSpeed()
        {
            if (_rigidbody.linearVelocity.sqrMagnitude > _maxSpeedSqr)
            {
                return true;
            }

            return false;
        }
    }
}
