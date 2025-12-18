using Asteroids.Spaceship;
using Asteroids.Spaceship.Movement;
using UnityEngine;
using Zenject;

namespace Asteroids.Installers
{
    public class SpaceshipSpawnerInstaller : MonoInstaller
    {
        [SerializeField] private Spaceship.Spaceship _spaceshipPrefab;
        
        public override void InstallBindings()
        {
            BindSpaceship();
            BindFactory();
        }

        private void BindSpaceship()
        {
            Container.Bind<Spaceship.Spaceship>()
                .FromInstance(_spaceshipPrefab)
                .AsSingle();
        }

        private void BindFactory()
        {
            Container.Bind<SpaceshipFactory>().AsSingle();
        }

        //private void BindSpaceshipContexts()
        //{
        //    Container.Bind<SpaceshipContext>()
        //            .WithId(SpaceshipType.Player)
        //            .FromMethod(GetPlayerSpaceshipContext)
        //            .AsCached();

        //    Container.Bind<SpaceshipContext>()
        //            .WithId(SpaceshipType.Enemy)
        //            .FromMethod(GetEnemySpaceshipContext)
        //            .AsCached();
        //}

        //private SpaceshipContext GetPlayerSpaceshipContext()
        //{
        //    ISpaceshipMover spaceshipMover = Container.ResolveId<ISpaceshipMover>(SpaceshipType.Player);
        //    ISpaceshipShooter spaceshipShooter = Container.ResolveId<ISpaceshipShooter>(SpaceshipType.Player);
        //    SpaceshipContext spaceshipContext = new SpaceshipContext(spaceshipMover, spaceshipShooter, Color.green);
        //    return spaceshipContext;
        //}

        //private SpaceshipContext GetEnemySpaceshipContext()
        //{ 
        //    ISpaceshipMover spaceshipMover = Container.ResolveId<ISpaceshipMover>(SpaceshipType.Enemy);
        //    ISpaceshipShooter spaceshipShooter = Container.ResolveId<ISpaceshipShooter>(SpaceshipType.Enemy);
        //    SpaceshipContext spaceshipContext = new SpaceshipContext(spaceshipMover, spaceshipShooter, Color.red);
        //    return spaceshipContext;
        //}
    }
}
