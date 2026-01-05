using Asteroids.Spaceship.Movement;
using Asteroids.Utils;
using Cysharp.Threading.Tasks;
using TMPro.EditorUtilities;
using UnityEngine;

namespace Asteroids.Spaceship.Movement
{
    public class EnemySpaceshipMover : ISpaceshipMover
    {
        private float _changeDestinationInterval;
        private float _maxSpeedSqr;
        private float _slowTurningDownAngle;
        private float _maxRadiusOffsetFromPlayer;
        private float _maxForwardToDestinationDot;
        private Vector2 _currentRadiusOffsetFromPlayer;
        private Rigidbody2D _rigidbody;
        private Rigidbody2D _playerRigidbody;

        public EnemySpaceshipMover(
            EnemySpaceshipMovementLogicSO enemySpaceshipMovementLogicSO,
            Rigidbody2D enemyRigidbody,
            Rigidbody2D playerRigidbody
            )
        {
            _rigidbody = enemyRigidbody;
            _playerRigidbody = playerRigidbody;

            CacheLogicData(enemySpaceshipMovementLogicSO);
            ChangeDestinationNearPlayerLoopAsync().Forget();
        }

        private void CacheLogicData(EnemySpaceshipMovementLogicSO enemySpaceshipMovementLogicSO)
        {
            _changeDestinationInterval = enemySpaceshipMovementLogicSO.ChangeDestinationInterval;
            _maxSpeedSqr = enemySpaceshipMovementLogicSO.MaxSpeedSqr;
            _slowTurningDownAngle = enemySpaceshipMovementLogicSO.SlowTurningDownAngle;
            _maxRadiusOffsetFromPlayer = enemySpaceshipMovementLogicSO.MaxRadiusOffsetFromPlayer;
            _maxForwardToDestinationDot = enemySpaceshipMovementLogicSO.MaxForwardToDestinationDot;
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
            float throttleValue;            
            Vector3 directionToDestination = GetDirectionToDestination();
            float forwardToDestinationDot = Vector2.Dot(_rigidbody.transform.up, directionToDestination);

            if (forwardToDestinationDot > _maxForwardToDestinationDot)
            {
                throttleValue = 1f;
            }
            else
            {
                throttleValue = 0f;
            }

            return throttleValue;
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
            Vector2 direction = (_playerRigidbody.position + 
                _currentRadiusOffsetFromPlayer - _rigidbody.position).normalized ;

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
