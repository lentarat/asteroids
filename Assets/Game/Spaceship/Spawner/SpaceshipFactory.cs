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
        private Rigidbody2D _playerRigidbody;
        private EnemySpaceshipMovementLogicSO _enemySpaceshipMovementLogicSO;

        [Inject]
        public SpaceshipFactory(
            Spaceship spaceshipPrefab,
            PlayerInputActions playerInputActions,
            SignalBus signalBus,
            EnemySpaceshipMovementLogicSO enemySpaceshipMovementLogicSO
            )
        {
            _spaceshipPrefab = spaceshipPrefab;
            _playerInputActions = playerInputActions;
            _signalBus = signalBus;
            _enemySpaceshipMovementLogicSO = enemySpaceshipMovementLogicSO;
        }

        public Spaceship CreatePlayerSpaceship()
        {
            Spaceship spaceship = GameObject.Instantiate(_spaceshipPrefab);
            spaceship.name = "Player" + spaceship.name;
            
            ISpaceshipMover spaceshipMover = new PlayerSpaceshipMovementInputReader(_playerInputActions);
            ISpaceshipShooter spaceshipShooter = new PlayerSpaceshipShootingReader(_playerInputActions);
            IDeathHandler deathHandler = new PlayerDeathHandler(_signalBus);
            Color color = Color.green;
            SpaceshipContext spaceshipContext =
                new(spaceshipMover, spaceshipShooter, deathHandler, color);
            spaceship.InitializeSpaceship(spaceshipContext);

            _playerRigidbody = spaceship.GetComponent<Rigidbody2D>();

            return spaceship;
        }

        public Spaceship CreateEnemySpaceship(Vector2 position)
        {
            Spaceship spaceship = GameObject.Instantiate(_spaceshipPrefab);
            spaceship.name = "Enemy" + spaceship.name;

            Rigidbody2D spaceshipRigidbody = spaceship.GetComponent<Rigidbody2D>();
            ISpaceshipMover spaceshipMover = new EnemySpaceshipMover(
                _enemySpaceshipMovementLogicSO, spaceshipRigidbody, _playerRigidbody
                );
            ISpaceshipShooter spaceshipShooter = new EnemySpaceshipShooter();
            IDeathHandler deathHandler = new EnemyDeathHandler();
            Color color = Color.red;
            SpaceshipContext spaceshipContext =
                new(spaceshipMover, spaceshipShooter, deathHandler, color);
            spaceship.InitializeSpaceship(spaceshipContext);

            spaceship.transform.position = position;

            return spaceship;
        }
    }
}