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

        [Inject]
        private void Construct(SpaceshipFactory spaceshipFactory)
        { 
            _spaceshipFactory = spaceshipFactory;
        }

        private void Start()
        {
            CreatePlayerSpaceship();
            SpawnEnemySpaceshipsLoopAsync().Forget();
        }

        private void CreatePlayerSpaceship()
        {
            _spaceshipFactory.CreatePlayerSpaceship();
        }

        private async UniTask SpawnEnemySpaceshipsLoopAsync()
        {
            while (true)
            {
                SpawnEnemySpaceship();
                await UniTask.WaitForSeconds(0.05f);
            }
        }

        private void SpawnEnemySpaceship()
        {
            //SpaceshipContext playerSpaceshipContext = new(playerSpaceshipMovementInputReader);
            //Spaceship spaceship = _spaceshipFactory.Create(playerSpaceshipContext);

            WorldBoundaries worldBoundaries = WorldBoundaryUtils.GetWorldBoundaries(Camera.main);
            Vector2 randomSpawnPosition = WorldBoundaryUtils.GetRandomPositionBeyondBoundaries(worldBoundaries);
            _spaceshipFactory.CreateEnemySpaceship(randomSpawnPosition);
            //spaceship.transform.position = randomSpawnPosition;
        }
    }
}
