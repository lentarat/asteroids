using Asteroids.Spaceship;
using Asteroids.Spaceship.Movement;
using Asteroids.Spaceship.Shooting;
using TMPro;
using UnityEditor.U2D.Animation;
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

        [Inject]
        public SpaceshipFactory(
            Spaceship spaceshipPrefab,
            PlayerInputActions playerInputActions,
            SignalBus signalBus
            )
        {
            _spaceshipPrefab = spaceshipPrefab;
            _playerInputActions = playerInputActions;
            _signalBus = signalBus;
        }

        public Spaceship CreatePlayerSpaceship()
        {
            Spaceship spaceship = GameObject.Instantiate(_spaceshipPrefab);
            spaceship.name = "Player" + spaceship.name;

            ISpaceshipMover spaceshipMover = new PlayerSpaceshipMovementInputReader(_playerInputActions);
            ISpaceshipShooter spaceshipShooter = new PlayerSpaceshipShootingReader(_playerInputActions);
            Color color = Color.green;
            SpaceshipContext spaceshipContext = new(spaceshipMover, spaceshipShooter, color);
            spaceship.InitializeSpaceship(spaceshipContext, _signalBus);

            _playerRigidbody = spaceship.GetComponent<Rigidbody2D>();

            return spaceship;
        }

        public Spaceship CreateEnemySpaceship(Vector2 position)
        {
            Spaceship spaceship = GameObject.Instantiate(_spaceshipPrefab);
            spaceship.name = "Enemy" + spaceship.name;

            Rigidbody2D spaceshipRigidbody = spaceship.GetComponent<Rigidbody2D>();
            ISpaceshipMover spaceshipMover = new EnemySpaceshipMover(spaceshipRigidbody, _playerRigidbody);
            ISpaceshipShooter spaceshipShooter = new EnemySpaceshipShooter();
            Color color = Color.red;
            SpaceshipContext spaceshipContext = new SpaceshipContext(spaceshipMover, spaceshipShooter, color);
            spaceship.InitializeSpaceship(spaceshipContext, _signalBus);

            spaceship.transform.position = position;

            return spaceship;
        }
    }
}