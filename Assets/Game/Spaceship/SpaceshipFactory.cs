using Asteroids.Spaceship;
using Asteroids.Spaceship.Movement;
using Asteroids.Spaceship.Shooting;
using TMPro;
using UnityEngine;
using Zenject;

namespace Asteroids.Spaceship
{
    public class SpaceshipFactory
    {
        private Spaceship _spaceshipPrefab;
        private PlayerInputActions _playerInputActions;
        private Transform _playerTransform;

        public SpaceshipFactory(
            Spaceship spaceshipPrefab,
            PlayerInputActions playerInputActions
            )
        {
            _spaceshipPrefab = spaceshipPrefab;
            _playerInputActions = playerInputActions;
        }

        public Spaceship CreatePlayerSpaceship()
        {
            Spaceship spaceship = GameObject.Instantiate(_spaceshipPrefab);

            ISpaceshipMover spaceshipMover = new PlayerSpaceshipMovementInputReader(_playerInputActions);
            ISpaceshipShooter spaceshipShooter = new PlayerSpaceshipShootingReader();
            Color color = Color.green;

            SpaceshipContext spaceshipContext = new(spaceshipMover, spaceshipShooter, color);
            spaceship.InitializeSpaceship(spaceshipContext);

            _playerTransform = spaceship.transform;

            return spaceship;
        }

        public Spaceship CreateEnemySpaceship(Vector2 position)
        {
            Spaceship spaceship = GameObject.Instantiate(_spaceshipPrefab);

            ISpaceshipMover spaceshipMover = new EnemySpaceshipMover(spaceship.transform, _playerTransform);
            ISpaceshipShooter spaceshipShooter = new EnemySpaceshipShooter();
            Color color = Color.red;

            SpaceshipContext spaceshipContext = new SpaceshipContext(spaceshipMover, spaceshipShooter, color);
            spaceship.InitializeSpaceship(spaceshipContext);
            spaceship.transform.position = position;

            return spaceship;
        }
    }

    //public class SpaceshipFactory
    //{
    //    private Spaceship _spaceshipPrefab;
    //    private SpaceshipContext _playerSpaceshipContext;
    //    private SpaceshipContext _enemySpaceshipContext;

    //    public SpaceshipFactory(
    //        Spaceship spaceshipPrefab,
    //        [Inject(Id = SpaceshipType.Player)] SpaceshipContext playerSpaceshipContext,
    //        [Inject(Id = SpaceshipType.Enemy)] SpaceshipContext enemySpaceshipContext)
    //    {
    //        _spaceshipPrefab = spaceshipPrefab;    
    //        _playerSpaceshipContext = playerSpaceshipContext;
    //        _enemySpaceshipContext = enemySpaceshipContext;
    //    }

    //    public void CreatePlayerSpaceship()
    //    {
    //        Spaceship spaceship = GameObject.Instantiate(_spaceshipPrefab);
    //        spaceship.InitializeSpaceship(_playerSpaceshipContext);   
    //    }

    //    public void CreateEnemySpaceship(Vector2 position)
    //    {
    //        Spaceship spaceship = GameObject.Instantiate(_spaceshipPrefab);
    //        spaceship.InitializeSpaceship(_enemySpaceshipContext);
    //        spaceship.transform.position = position;
    //    }
    //}
}