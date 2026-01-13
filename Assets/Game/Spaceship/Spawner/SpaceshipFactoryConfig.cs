using Asteroids.General.Audio;
using Asteroids.Spaceship;
using Asteroids.Spaceship.Movement;
using Asteroids.Spaceship.Shooting;
using UnityEngine;
using Zenject;

namespace Asteroids.Spaceship.Creation
{
    public class SpaceshipFactoryConfig
    {
        public Spaceship SpaceshipPrefab { get; }
        public Transform EnemySpaceshipsParent { get; }
        public Transform ProjectilesParent { get; }
        public LayerMask PlayerLayer { get; }
        public LayerMask EnemyLayer { get; }
        public EnemySpaceshipMovementLogicSO EnemyMovementLogic { get; }
        public PlayerInputActions PlayerInputActions { get; }
        public SignalBus SignalBus { get; }
        public AudioSourcePool AudioSourcePool { get; }

        public SpaceshipFactoryConfig(
            Spaceship spaceshipPrefab,
            Transform projectilesParent,
            Transform enemySpaceshipsParent,
            LayerMask playerLayer,
            LayerMask enemyLayer,
            EnemySpaceshipMovementLogicSO enemyMovementLogic,
            PlayerInputActions playerInputActions,
            SignalBus signalBus,
            AudioSourcePool audioSourcePool
            )
        {
            SpaceshipPrefab = spaceshipPrefab;
            ProjectilesParent = projectilesParent;
            EnemySpaceshipsParent = enemySpaceshipsParent;
            PlayerLayer = playerLayer;
            EnemyLayer = enemyLayer;
            EnemyMovementLogic = enemyMovementLogic;
            PlayerInputActions = playerInputActions;
            SignalBus = signalBus;
            AudioSourcePool = audioSourcePool;
        }
    }
}