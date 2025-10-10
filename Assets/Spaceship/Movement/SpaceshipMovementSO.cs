using UnityEngine;

namespace Asteroids.Spaceship.Movement
{
    [CreateAssetMenu(fileName = "SpaceshipMovementSO", menuName = "ScriptableObjects/SpaceshipMovementSO")]
    public class SpaceshipMovementSO : ScriptableObject
    {
        [SerializeField] private float _acceleration;
        public float Acceleration => _acceleration;
        [SerializeField] private float _angularAcceleration;
        public float AngularAcceleration => _angularAcceleration;
    }
}
