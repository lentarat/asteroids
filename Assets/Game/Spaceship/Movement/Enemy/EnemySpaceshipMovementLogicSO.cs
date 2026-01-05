using UnityEngine;

namespace Asteroids.Spaceship.Movement
{
    [CreateAssetMenu(
        fileName = "EnemySpaceshipMovementLogicSO",
        menuName = "ScriptableObjects/EnemySpaceshipMovementLogicSO"
        )]
    public class EnemySpaceshipMovementLogicSO : ScriptableObject
    {
        [SerializeField] private float _changeDestinationInterval = 5f;
        public float ChangeDestinationInterval => _changeDestinationInterval;
        [SerializeField] private float _maxSpeedSqr = 1f;
        public float MaxSpeedSqr => _maxSpeedSqr;
        [SerializeField] private float _slowTurningDownAngle = 150f;
        public float SlowTurningDownAngle => _slowTurningDownAngle;
        [SerializeField] private float _maxRadiusOffsetFromPlayer = 1.5f;
        public float MaxRadiusOffsetFromPlayer => _maxRadiusOffsetFromPlayer;
        [SerializeField] private float _maxForwardToDestinationDot = 0.8f;
        public float MaxForwardToDestinationDot => _maxForwardToDestinationDot;
    }
}
