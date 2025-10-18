using Asteroids.Spaceship.Movement;
using UnityEngine;
using Zenject;

namespace Asteroids.Spaceship
{
    public class Spaceship : MonoBehaviour
    {

        private SpaceshipData _playerSpaceshipData;
        private SpaceshipLogic _playerSpaceshipLogic;

        //[Inject]
        //private void Construct(ISpaceshipMover spaceshipMover)
        //{
        //    spaceshipMover
        //}
    }
}
