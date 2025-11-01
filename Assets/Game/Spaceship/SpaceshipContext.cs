using Asteroids.Spaceship.Movement;
using UnityEngine;

namespace Asteroids.Spaceship
{
    public struct SpaceshipContext
    {
        public ISpaceshipMover SpaceshipMover { get; private set; }
        public ISpaceshipShooter SpaceshipShooter { get; private set; }
        public Color Color { get; private set; }

        public SpaceshipContext(
            ISpaceshipMover spaceshipMover,
            ISpaceshipShooter spaceshipShooter,
            Color color)
        {
            SpaceshipMover = spaceshipMover;
            SpaceshipShooter = spaceshipShooter;
            Color = color;
        }
    }
}
