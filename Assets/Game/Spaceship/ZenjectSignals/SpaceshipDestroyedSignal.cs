using UnityEngine;

namespace Asteroids.Signals
{
    public struct SpaceshipDestroyedSignal
    {
        public Spaceship.Spaceship Spaceship { get; private set; }

        public SpaceshipDestroyedSignal(Spaceship.Spaceship spaceship)
        {
            Spaceship = spaceship;
        }
    }
}