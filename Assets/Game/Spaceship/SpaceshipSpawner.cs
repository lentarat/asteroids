using UnityEngine;
using Cysharp.Threading.Tasks;
using Zenject;
using Asteroids.Spaceship.Movement;
using Asteroids.Utils;

namespace Asteroids.Spaceship
{
    public class SpaceshipSpawner : MonoBehaviour
    {
        [SerializeField] private float _enemySpaceshipSpawnInterval;
        [SerializeField] private Transform _enemySpaceshipsHolder;

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
                await UniTask.WaitForSeconds(_enemySpaceshipSpawnInterval);
            }
        }

        private void SpawnEnemySpaceship()
        {
            WorldBoundaries worldBoundaries = WorldBoundaryUtils.GetWorldBoundaries(Camera.main);
            Vector2 randomSpawnPosition = WorldBoundaryUtils.GetRandomPositionBeyondBoundaries(worldBoundaries);
            Spaceship enemySpaceship = _spaceshipFactory.CreateEnemySpaceship(randomSpawnPosition);
            enemySpaceship.transform.parent = _enemySpaceshipsHolder;
        }
    }
}
