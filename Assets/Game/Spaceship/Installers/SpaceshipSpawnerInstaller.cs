using Asteroids.Spaceship;
using Asteroids.Spaceship.Movement;
using UnityEngine;
using Zenject;

namespace Asteroids.Installers
{
    public class SpaceshipSpawnerInstaller : MonoInstaller
    {
        [SerializeField] private Spaceship.Spaceship _spaceshipPrefab;
        [SerializeField] private Transform _spaceshipParent;
        
        public override void InstallBindings()
        {
            BindSpaceship();
            BindSpaceshipContexts();
            BindFactory();
        }

        private void BindSpaceship()
        {
            Container.Bind<Spaceship.Spaceship>()
                .FromComponentInNewPrefab(_spaceshipPrefab)
                .AsSingle();
        }

        private void BindSpaceshipContexts()
        {
            Container.Bind<SpaceshipContext>()
                    .WithId(SpaceshipType.Player)
                    .FromMethod(GetPlayerSpaceshipContext)
                    .AsSingle();

            Container.Bind<SpaceshipContext>()
                    .WithId(SpaceshipType.Enemy)
                    .FromMethod(GetEnemySpaceshipContext)
                    .AsSingle();
        }

        private void BindFactory()
        {
            Container.Bind<SpaceshipFactory>().AsSingle();
        }

        private SpaceshipContext GetPlayerSpaceshipContext()
        {
            ISpaceshipMover spaceshipMover = Container.ResolveId<ISpaceshipMover>(SpaceshipType.Player);
            ISpaceshipShooter spaceshipShooter = Container.ResolveId<ISpaceshipShooter>(SpaceshipType.Player);
            SpaceshipContext playerSpaceshipContext = new SpaceshipContext(spaceshipMover, spaceshipShooter, Color.green);
            return playerSpaceshipContext;
        }

        private SpaceshipContext GetEnemySpaceshipContext()
        {
            return default;
            //ISpaceshipMover spaceshipMover = Container.ResolveId<ISpaceshipMover>(SpaceshipType.Player);
            //ISpaceshipShooter spaceshipShooter = Container.ResolveId<ISpaceshipShooter>(SpaceshipType.Player);
            //SpaceshipContext playerSpaceshipContext = new SpaceshipContext(spaceshipMover, spaceshipShooter, Color.green);
            //return playerSpaceshipContext;
        }

        private SpaceshipContext BuildSpaceshipContext()
        {
            //ISpaceshipMover spaceshipMover =

            //SpaceshipContext spaceshipContext = new(spaceshipMover, spaceshipShooter, color);
            //return spaceshipContext;
            return default;
        }
    }
}
