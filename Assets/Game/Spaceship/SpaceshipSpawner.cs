using UnityEngine;
using Cysharp.Threading.Tasks;
using Zenject;
using Asteroids.Spaceship.Movement;

namespace Asteroids.Spaceship
{
    public class SpaceshipSpawner : MonoBehaviour
    {
        private SpaceshipFactory _spaceshipFactory;
        private PlayerInputActions _playerInputActions;

        [Inject]
        private void Construct(
            SpaceshipFactory spaceshipFactory,
            PlayerInputActions playerInputActions)
        { 
            _spaceshipFactory = spaceshipFactory;
            _playerInputActions = playerInputActions;
        }

        private void Start()
        {
            CreatePlayerSpaceship();
            SpawnEnemySpaceshipsLoopAsync().Forget();
        }

        private void CreatePlayerSpaceship()
        {
            PlayerSpaceshipMovementInputReader playerSpaceshipMovementInputReader
             = new(_playerInputActions);
            SpaceshipContext playerSpaceshipContext = new(playerSpaceshipMovementInputReader);
            _spaceshipFactory.Create(playerSpaceshipContext);
        }

        private UniTask SpawnEnemySpaceshipsLoopAsync()
        {
            while (true)
            {
                SpawnEnemySpaceship();

                UniTask.WaitForSeconds(1);
            }
        }

        private void SpawnEnemySpaceship()
        {
        }
    }
}
