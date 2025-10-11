using System;
using UnityEngine;

namespace Asteroids.Spaceship.Movement
{
    public interface ISpaceshipMover
    {
        int GetThrottleValue();
        float GetTurnDirectionValue();
    }
}