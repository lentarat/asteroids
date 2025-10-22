using Asteroids.Spaceship.Movement;
using UnityEngine;

public class EnemySpaceshipMover : ISpaceshipMover
{
    float ISpaceshipMover.GetThrottleValue()
    {
        throw new System.NotImplementedException();
    }

    float ISpaceshipMover.GetTurnDirectionValue()
    {
        throw new System.NotImplementedException();
    }
}
