using Asteroids.Spaceship.Movement;
using UnityEngine;

namespace Asteroids.Spaceship
{
    public struct SpaceshipContext
    {
        public SpaceshipType SpaceshipType { get; private set; }
        public ISpaceshipMover SpaceshipMover { get; private set; }
        public ISpaceshipShooter SpaceshipShooter { get; private set; }
        public Color Color { get; private set; }

        public SpaceshipContext(
            SpaceshipType spaceshipType,
            ISpaceshipMover spaceshipMover,
            ISpaceshipShooter spaceshipShooter,
            Color color)
        {
            SpaceshipType = spaceshipType;
            SpaceshipMover = spaceshipMover;
            SpaceshipShooter = spaceshipShooter;
            Color = color;
        }
    }
}
