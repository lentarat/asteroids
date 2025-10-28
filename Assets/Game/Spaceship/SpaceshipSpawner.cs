using UnityEngine;
using Cysharp.Threading.Tasks;
using Zenject;
using Asteroids.Spaceship.Movement;
using Asteroids.Utils;

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
            Spaceship spaceship = _spaceshipFactory.Create(playerSpaceshipContext);
        }

        private async UniTask SpawnEnemySpaceshipsLoopAsync()
        {
            while (true)
            {
                SpawnEnemySpaceship();

                await UniTask.WaitForSeconds(1);
            }
        }

        private void SpawnEnemySpaceship()
        {
            PlayerSpaceshipMovementInputReader playerSpaceshipMovementInputReader
             = new(_playerInputActions);
            SpaceshipContext playerSpaceshipContext = new(playerSpaceshipMovementInputReader);
            Spaceship spaceship = _spaceshipFactory.Create(playerSpaceshipContext);

            WorldBoundaries worldBoundaries = WorldBoundaries.GetWorldBoundaries();
            spaceship.transform.position = worldBoundaries.LeftUpper;

        }

        private Vector2 GetRandomPosition
    }
}
