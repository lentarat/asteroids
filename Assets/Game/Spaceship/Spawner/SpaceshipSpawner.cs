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
        [SerializeField] private LayerMask _playerLayerMask;
        [SerializeField] private LayerMask _enemyLayerMask;

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
            playerSpaceship.gameObject.layer = _playerLayerMask;
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
            enemySpaceship.gameObject.layer = _enemyLayerMask;
        }
    }
}
