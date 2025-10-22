using Asteroids.Spaceship.Movement;
using UnityEngine;
using Zenject;

namespace Asteroids.Spaceship
{
    public class Spaceship : MonoBehaviour
    {

        private SpaceshipData _playerSpaceshipData;
        private SpaceshipLogic _playerSpaceshipLogic;

        private SpaceshipMovement _spaceshipMovement;

        public Spaceship(SpaceshipContext spaceshipContext)
        {
            
        }// prefabs vs runtime
    }
}
