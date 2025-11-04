using Asteroids.Spaceship.Movement;
using Asteroids.Spaceship.Shooting;
using Zenject;

namespace Asteroids.Installers
{
    public class SpaceshipContextFieldsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindPlayerSpaceshipContextFields();
            BindEnemySpaceshipContextFields();
        }

        private void BindPlayerSpaceshipContextFields()
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

        private void BindEnemySpaceshipContextFields()
        {
            Container.Bind<ISpaceshipMover>()
                .WithId(SpaceshipType.Enemy)
                .To<EnemySpaceshipMover>()
                .AsSingle();

            Container.Bind<ISpaceshipShooter>()
                .WithId(SpaceshipType.Enemy)
                .To<EnemySpaceshipShooter>() //////////////////////////////////
                .AsSingle();
        }
    }
}
