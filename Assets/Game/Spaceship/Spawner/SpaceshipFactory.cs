using Asteroids.General.Audio;
using Asteroids.Spaceship;
using Asteroids.Spaceship.Death;
using Asteroids.Spaceship.Movement;
using Asteroids.Spaceship.Shooting;
using UnityEngine;
using Zenject;

namespace Asteroids.Spaceship
{
    public class SpaceshipFactory
    {
        private Spaceship _spaceshipPrefab;
        private PlayerInputActions _playerInputActions;
        private SignalBus _signalBus;
        private EnemySpaceshipMovementLogicSO _enemySpaceshipMovementLogicSO;
        private AudioSourcePool _audioSourcePool;
        private Rigidbody2D _playerRigidbody;

        [Inject]
        public SpaceshipFactory(
            Spaceship spaceshipPrefab,
            PlayerInputActions playerInputActions,
            SignalBus signalBus,
            EnemySpaceshipMovementLogicSO enemySpaceshipMovementLogicSO,
            AudioSourcePool audioSourcePool
            )
        {
            _spaceshipPrefab = spaceshipPrefab;
            _playerInputActions = playerInputActions;
            _signalBus = signalBus;
            _enemySpaceshipMovementLogicSO = enemySpaceshipMovementLogicSO;
            _audioSourcePool = audioSourcePool;
        }

        public Spaceship CreatePlayerSpaceship()
        {
            string spaceshipName = "Player";
            Spaceship spaceship = CreateBaseSpaceship(spaceshipName);

            ISpaceshipMover spaceshipMover = new PlayerSpaceshipMover(_playerInputActions);
            ISpaceshipShooter spaceshipShooter = new PlayerSpaceshipShooter(_playerInputActions);
            IDeathHandler deathHandler = new PlayerDeathHandler(_signalBus);
            Color color = Color.green;
            SpaceshipContext spaceshipContext =
                new(spaceshipMover, spaceshipShooter, deathHandler, color);
            spaceship.InitializeContext(spaceshipContext);

            _playerRigidbody = spaceship.GetComponent<Rigidbody2D>();

            return spaceship;
        }

        private Spaceship CreateBaseSpaceship(string name)
        {
            Spaceship spaceship = GameObject.Instantiate(_spaceshipPrefab);
            spaceship.name = name + spaceship.name;
            spaceship.Init(_audioSourcePool);

            return spaceship;
        }

        public Spaceship CreateEnemySpaceship(Vector2 position)
        {
            string spaceshipName = "Enemy";
            Spaceship spaceship = CreateBaseSpaceship(spaceshipName);

            Rigidbody2D spaceshipRigidbody = spaceship.GetComponent<Rigidbody2D>();
            ISpaceshipMover spaceshipMover = new EnemySpaceshipMover(
                _enemySpaceshipMovementLogicSO, spaceshipRigidbody, _playerRigidbody
                );
            ISpaceshipShooter spaceshipShooter = new EnemySpaceshipShooter();
            IDeathHandler deathHandler = new EnemyDeathHandler();
            Color color = Color.red;
            SpaceshipContext spaceshipContext =
                new(spaceshipMover, spaceshipShooter, deathHandler, color);
            spaceship.InitializeContext(spaceshipContext);

            spaceship.transform.position = position;

            return spaceship;
        }
    }
}