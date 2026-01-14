using Asteroids.General.Audio;
using Asteroids.Spaceship;
using Asteroids.Spaceship.Death;
using Asteroids.Spaceship.Movement;
using Asteroids.Spaceship.Shooting;
using UnityEngine;
using Zenject;

namespace Asteroids.Spaceship.Creation
{
    public class SpaceshipFactory
    {
        private readonly SpaceshipFactoryConfig _spaceshipFactoryConfig;
        private Rigidbody2D _playerRigidbody;

        [Inject]
        public SpaceshipFactory(SpaceshipFactoryConfig spaceshipFactoryConfig)
        {
            _spaceshipFactoryConfig = spaceshipFactoryConfig;
        }

        public Spaceship CreatePlayerSpaceship()
        {
            string spaceshipName = "Player";
            Spaceship spaceship = CreateBaseSpaceship(spaceshipName);

            PlayerInputActions playerInputActions = _spaceshipFactoryConfig.PlayerInputActions;
            SignalBus signalBus = _spaceshipFactoryConfig.SignalBus;
            ISpaceshipMover spaceshipMover = new PlayerSpaceshipMover(playerInputActions);
            ISpaceshipShooter spaceshipShooter = new PlayerSpaceshipShooter(playerInputActions);
            IDeathHandler deathHandler = new PlayerDeathHandler(signalBus);
            Color color = Color.green;

            SpaceshipContext spaceshipContext = new(spaceshipMover, spaceshipShooter, deathHandler, color);
            spaceship.InitializeContext(spaceshipContext);
            spaceship.gameObject.layer = _spaceshipFactoryConfig.PlayerLayer;

            _playerRigidbody = spaceship.GetComponent<Rigidbody2D>();
            return spaceship;
        }

        public Spaceship CreateEnemySpaceship(Vector2 position)
        {
            string spaceshipName = "Enemy";
            Spaceship spaceship = CreateBaseSpaceship(spaceshipName);
            Rigidbody2D spaceshipRigidbody = spaceship.GetComponent<Rigidbody2D>();

            EnemySpaceshipMovementLogicSO enemySpaceshipMovementLogicSO =
                _spaceshipFactoryConfig.EnemyMovementLogic;
            ISpaceshipMover spaceshipMover = new EnemySpaceshipMover(
                enemySpaceshipMovementLogicSO, spaceshipRigidbody, _playerRigidbody
                );
            ISpaceshipShooter spaceshipShooter = new EnemySpaceshipShooter();
            IDeathHandler deathHandler = new EnemyDeathHandler();
            Color color = Color.red;

            SpaceshipContext spaceshipContext = new(spaceshipMover, spaceshipShooter, deathHandler, color);
            spaceship.InitializeContext(spaceshipContext);
            spaceship.transform.position = position;
            spaceship.transform.parent = _spaceshipFactoryConfig.EnemySpaceshipsParent;
            spaceship.gameObject.layer = _spaceshipFactoryConfig.EnemyLayer;

            return spaceship;
        }

        private Spaceship CreateBaseSpaceship(string name)
        {
            Spaceship spaceshipPrefab = _spaceshipFactoryConfig.SpaceshipPrefab;
            Spaceship spaceship = GameObject.Instantiate(spaceshipPrefab);
            spaceship.name = name + spaceship.name;
            spaceship.Init(_spaceshipFactoryConfig.AudioSourcePool, _spaceshipFactoryConfig.ProjectilesParent);
            return spaceship;
        }
    }
}