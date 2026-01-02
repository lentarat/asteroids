using Asteroids.Spaceship.Death;
using Asteroids.Spaceship.Movement;
using UnityEngine;

namespace Asteroids.Spaceship
{
    public struct SpaceshipContext
    {
        public ISpaceshipMover SpaceshipMover { get; private set; }
        public ISpaceshipShooter SpaceshipShooter { get; private set; }
        public IDeathHandler DeathHandler { get; private set; }
        public Color Color { get; private set; }

        public SpaceshipContext(
            ISpaceshipMover spaceshipMover,
            ISpaceshipShooter spaceshipShooter,
            IDeathHandler deathHandler,
            Color color)
        {
            SpaceshipMover = spaceshipMover;
            SpaceshipShooter = spaceshipShooter;
            DeathHandler = deathHandler;
            Color = color;
        }
    }
}
