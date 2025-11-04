using Asteroids.Spaceship.Movement;
using UnityEngine;

public class EnemySpaceshipMover : ISpaceshipMover
{
    //private Transform _enemyTransform;

    //public EnemySpaceshipMover(Transform enemyTransform)
    //{
    //    _enemyTransform = enemyTransform;   
    //}

    float ISpaceshipMover.GetThrottleValue()
    {
        return 0f;
    }

    float ISpaceshipMover.GetTurnDirectionValue()
    {
        return 0f;
    }
}
