using Asteroids.Spaceship.Movement;
using Asteroids.Utils;
using Cysharp.Threading.Tasks;
using TMPro.EditorUtilities;
using UnityEngine;

namespace Asteroids.Spaceship.Movement
{
    public class EnemySpaceshipMover : ISpaceshipMover
    {
        private float _followPlayerRadius = 2f;
        private float _changeDestinationInterval = 5f;
        private float _maxSpeedSqr = 1f;
        private Vector2 _currentDestinationPosition;
        private Rigidbody2D _rigidbody;
        private Rigidbody2D _playerRigidbody;

        public EnemySpaceshipMover(
            Rigidbody2D enemyRigidbody,
            Rigidbody2D playerRigidbody
            )
        {
            _rigidbody = enemyRigidbody;
            _playerRigidbody = playerRigidbody;

            ChangeDestinationLoopAsync().Forget();
        }

        private async UniTask ChangeDestinationLoopAsync()
        {
            WorldBoundaries worldBoundaries = WorldBoundaryUtils.GetWorldBoundaries(Camera.main);
            float xMax = worldBoundaries.RightVector.x;
            float yMax = worldBoundaries.UpperVector.y;
            float circleRadius = Mathf.Min(xMax, yMax);

            while (true)
            {
                _currentDestinationPosition = Random.insideUnitCircle * circleRadius;
                await UniTask.WaitForSeconds(_changeDestinationInterval);
            }
        }

        float ISpaceshipMover.GetThrottleValue()
        {
            return 0f;
        }

        float ISpaceshipMover.GetTurnDirectionValue()
        {
            float turnDirectionValue;
            bool hasAccededMaxSpeed = HasAccededMaxSpeed();

            if(hasAccededMaxSpeed == false)
            {
                Vector3 directionToDestination = GetDirectionToDestination();
                float signedAngleToDirection = Vector2.SignedAngle(directionToDestination, _rigidbody.transform.up);
                
                turnDirectionValue = Vector2.Dot(directionToDestination, _rigidbody.transform.up) - 1;
                turnDirectionValue = Mathf.Clamp01(turnDirectionValue);
                turnDirectionValue *= Mathf.Sign(signedAngleToDirection);  
                
                return turnDirectionValue;
            }

            Vector3 enemyToPlayerVector = (_playerRigidbody.position - _rigidbody.position).normalized;
            float signedAngleToPlayer = Vector2.SignedAngle(enemyToPlayerVector, _rigidbody.transform.up);

            if (signedAngleToPlayer > 0)
            {
                turnDirectionValue = 1f;
            }
            else
            {
                turnDirectionValue = -1f;
            }

            return turnDirectionValue;
        }

        private Vector2 GetDirectionToDestination()
        {
            Vector2 direction = (_playerRigidbody.position - _rigidbody.position).normalized;
            return direction;
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
