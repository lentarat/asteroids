using Asteroids.Spaceship;
using Asteroids.Spaceship.Movement;
using UnityEngine;
using Zenject;

namespace Asteroids.Installers
{
    public class SpaceshipSpawnerInstaller : MonoInstaller
    {
        [SerializeField] private Spaceship.Spaceship _spaceshipPrefab;
        [SerializeField] private EnemySpaceshipMovementLogicSO _enemySpaceshipMovementLogicSO;
        
        public override void InstallBindings()
        {
            BindSpaceship();
            BindEnemySpaceshipMovementLogicSO();
            BindFactory();
        }

        private void BindSpaceship()
        {
            Container.Bind<Spaceship.Spaceship>()
                .FromInstance(_spaceshipPrefab)
                .AsSingle();
        }

        private void BindEnemySpaceshipMovementLogicSO()
        {
            Container.Bind<EnemySpaceshipMovementLogicSO>().FromInstance(_enemySpaceshipMovementLogicSO);
        }

        private void BindFactory()
        {
            Container.Bind<SpaceshipFactory>().AsSingle();
        }
    }
}
