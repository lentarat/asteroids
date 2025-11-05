using Asteroids.Spaceship.Movement;
using TMPro.EditorUtilities;
using UnityEngine;

namespace Asteroids.Spaceship.Movement
{
    public class EnemySpaceshipMover : ISpaceshipMover
    {
        private Transform _transform;
        private Transform _playerTransform;

        public EnemySpaceshipMover(
            Transform enemyTransform,
            Transform playerTransform
            )
        {
            _transform = enemyTransform;
            _playerTransform = playerTransform;
        }

        float ISpaceshipMover.GetThrottleValue()
        {
            return 0f;
        }

        float ISpaceshipMover.GetTurnDirectionValue()
        {
            Vector3 enemyToPlayerVector = (_playerTransform.position - _transform.position).normalized;
            float signedAngle = Vector2.SignedAngle(enemyToPlayerVector, _transform.up);

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
    }
}
