using Asteroids.Spaceship.Movement;
using UnityEngine;

namespace Asteroids.Spaceship
{
    public class SpaceshipContext
    {
        public ISpaceshipMover SpaceshipMover { get; private set; }

        public SpaceshipContext(ISpaceshipMover spaceshipMover)
        {
            SpaceshipMover = spaceshipMover;
        }
    }
}
