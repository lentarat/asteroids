using UnityEngine;
using Cysharp.Threading.Tasks;
using Zenject;
using Asteroids.Spaceship.Movement;
using Asteroids.Utils;

namespace Asteroids.Spaceship.Creation
{
    public class SpaceshipSpawner : MonoBehaviour
    {
        [SerializeField] private bool _spawnEnemies;
        [SerializeField] private float _enemySpaceshipSpawnInterval;

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
            Spaceship playerSpaceship = _spaceshipFactory.CreatePlayerSpaceship();
        }

        private async UniTask SpawnEnemySpaceshipsLoopAsync()
        {
            while (true)
            {
                if (_spawnEnemies == false)
                {
                    await UniTask.Yield();
                    continue;
                }

                SpawnEnemySpaceship();
                await UniTask.WaitForSeconds(_enemySpaceshipSpawnInterval);
            }
        }

        private void SpawnEnemySpaceship()
        {
            WorldBoundaries worldBoundaries = WorldBoundaryUtils.GetWorldBoundaries(Camera.main);
            Vector2 randomSpawnPosition = WorldBoundaryUtils.GetRandomPositionBeyondBoundaries(worldBoundaries);
            
            Spaceship enemySpaceship = _spaceshipFactory.CreateEnemySpaceship(randomSpawnPosition);
        }
    }
}
