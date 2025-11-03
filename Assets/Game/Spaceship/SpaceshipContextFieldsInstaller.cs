using Asteroids.Spaceship.Movement;
using Asteroids.Spaceship.Shooting;
using UnityEngine;
using Zenject;

namespace Asteroids.Installers
{
    public class SpaceshipContextFieldsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindPlayerSpaceshipContext();
        }

        private void BindPlayerSpaceshipContext()
        {
            Container.Bind<ISpaceshipMover>()
                .WithId(SpaceshipType.Player)
                .To<PlayerSpaceshipMovementInputReader>()
                .AsSingle();

            Container.Bind<ISpaceshipShooter>()
                .WithId(SpaceshipType.Player)
                .To<PlayerSpaceshipShootingReader>()
                .AsSingle();
        }
    }
}
