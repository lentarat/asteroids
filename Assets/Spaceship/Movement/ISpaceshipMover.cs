using System;
using UnityEngine;

namespace Asteroids.Spaceship.Movement
{
    public interface ISpaceshipMover
    {
        float GetThrottleValue();
        float GetTurnDirectionValue();
    }
}