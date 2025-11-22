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
        private float _slowTurningDownAngle = 150f;
        private float _maxRadiusOffsetFromPlayer = 3f;
        private Vector2 _currentRadiusOffsetFromPlayer;
        private Rigidbody2D _rigidbody;
        private Rigidbody2D _playerRigidbody;

        public EnemySpaceshipMover(
            Rigidbody2D enemyRigidbody,
            Rigidbody2D playerRigidbody
            )
        {
            _rigidbody = enemyRigidbody;
            _playerRigidbody = playerRigidbody;

            ChangeDestinationNearPlayerLoopAsync().Forget();
        }

        private async UniTask ChangeDestinationNearPlayerLoopAsync()
        {
            while (true)
            {
                _currentRadiusOffsetFromPlayer = Random.insideUnitCircle * _maxRadiusOffsetFromPlayer;

                await UniTask.WaitForSeconds(_changeDestinationInterval);
            }
        }

        float ISpaceshipMover.GetThrottleValue()
        {
            return 0f;
        }

        float ISpaceshipMover.GetTurnDirectionValue()
        {
            Vector3 directionToDestination = GetDirectionToDestination();
            float signedAngleToDirection = Vector2.SignedAngle(directionToDestination, _rigidbody.transform.up);

            float turnDirectionValue = signedAngleToDirection / _slowTurningDownAngle;
            turnDirectionValue = Mathf.Clamp(turnDirectionValue, -1f, 1f);

            return turnDirectionValue;
        }

        private Vector2 GetDirectionToDestination()
        {
            Vector2 direction = (_playerRigidbody.position - _rigidbody.position).normalized +
                _currentRadiusOffsetFromPlayer;

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
