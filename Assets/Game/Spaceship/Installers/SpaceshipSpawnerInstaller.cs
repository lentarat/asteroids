using Asteroids.General.Audio;
using Asteroids.Spaceship.Creation;
using Asteroids.Spaceship.Movement;
using UnityEngine;
using Zenject;

namespace Asteroids.Installers
{
    public class SpaceshipSpawnerInstaller : MonoInstaller
    {
        [SerializeField] private Spaceship.Spaceship _spaceshipPrefab;
        [SerializeField] private Transform _projectilesParent;
        [SerializeField] private Transform _enemySpaceshipsParent;
        [SerializeField] private EnemySpaceshipMovementLogicSO _enemySpaceshipMovementLogicSO;
        [SerializeField] private LayerMask _playerLayer;
        [SerializeField] private LayerMask _enemyLayer;

        private string _projectilesParentID = "ProjectilesParent";

        private PlayerInputActions _playerInputActions;
        private SignalBus _signalBus;
        private AudioSourcePool _audioSourcePool;

        [Inject]
        private void Construct(
            PlayerInputActions playerInputActions,
            SignalBus signalBus,
            AudioSourcePool audioSourcePool)
        {
            _playerInputActions = playerInputActions;
            _signalBus = signalBus;
            _audioSourcePool = audioSourcePool;
        }

        public override void InstallBindings()
        {
            BindSpaceshipFactoryConfig();
            BindFactory();
        }

        private void BindSpaceshipFactoryConfig()
        {
            SpaceshipFactoryConfig spaceshipFactoryConfig = new SpaceshipFactoryConfig(
                _spaceshipPrefab,
                _projectilesParent,
                _enemySpaceshipsParent,
                _playerLayer,
                _enemyLayer,
                _enemySpaceshipMovementLogicSO,
                _playerInputActions,
                _signalBus,
                _audioSourcePool
            );

            Container.Bind<SpaceshipFactoryConfig>().
                FromInstance(spaceshipFactoryConfig).
                AsSingle();
        }

        private void BindSpaceship()
        {
            Container.Bind<Transform>().
                WithId(_projectilesParentID).
                FromInstance(_projectilesParent);

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
