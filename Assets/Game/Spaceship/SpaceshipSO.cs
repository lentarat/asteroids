using UnityEngine;
using Asteroids.Spaceship.Movement;

namespace Asteroids.Spaceship
{
    [CreateAssetMenu(fileName = "SpaceshipSO", menuName = "ScriptableObjects/SpaceshipSO")]
    public class SpaceshipSO : ScriptableObject
    {
        [SerializeField] private SpaceshipMovementSO _spaceshipMovementSO;
    }
}
