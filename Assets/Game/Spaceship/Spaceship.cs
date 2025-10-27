using Asteroids.Spaceship.Movement;
using UnityEngine;
using Zenject;

namespace Asteroids.Spaceship
{
    public class Spaceship : MonoBehaviour
    {

        private SpaceshipData _playerSpaceshipData;
        private SpaceshipLogic _playerSpaceshipLogic;

        [SerializeField] private SpaceshipMovement _spaceshipMovement;

        [Inject]
        private void Construct(SpaceshipContext spaceshipContext)
        {
            InitializeSpaceshipMovement(spaceshipContext);
        }

        private void InitializeSpaceshipMovement(SpaceshipContext spaceshipContext)
        {
            ISpaceshipMover spaceshipMover = spaceshipContext.SpaceshipMover;
            _spaceshipMovement.Init(spaceshipMover);
        }
    }
}
