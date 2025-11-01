using Asteroids.Spaceship;
using Asteroids.Spaceship.Movement;
using TMPro;
using UnityEngine;
using Zenject;

namespace Asteroids.Spaceship
{
    public class SpaceshipFactory
    {
        private Spaceship _spaceshipPrefab;
        private SpaceshipContext _playerSpaceshipContext;
        private SpaceshipContext _enemySpaceshipContext;

        public SpaceshipFactory(
            Spaceship spaceshipPrefab,
            [Inject(Id = SpaceshipType.Player)] SpaceshipContext playerSpaceshipContext,
            [Inject(Id = SpaceshipType.Enemy)] SpaceshipContext enemySpaceshipContext)
        {
            _spaceshipPrefab = spaceshipPrefab;    
            _playerSpaceshipContext = playerSpaceshipContext;
            _enemySpaceshipContext = enemySpaceshipContext;
        }

        public void CreatePlayerSpaceship()
        {
            Spaceship playerSpaceship = GameObject.Instantiate(_spaceshipPrefab);
            playerSpaceship.InitializeSpaceship(_playerSpaceshipContext);
            
        }

        public void CreateEnemySpaceship()
        { 
            
        }
    }

    //public class SpaceshipFactory : PlaceholderFactory<SpaceshipContext, Spaceship>
    //{
    //    public override Spaceship Create(SpaceshipContext spaceshipContext)
    //    {
    //        Spaceship spaceship = base.Create(spaceshipContext);
    //    }
    //}
}