using Asteroids.Spaceship.Movement;
using UnityEngine;
using Zenject;

namespace Asteroids.Spaceship
{
    public class Spaceship : MonoBehaviour
    {
        [SerializeField] private SpaceshipMovement _spaceshipMovement;

        public void InitializeSpaceship(SpaceshipContext spaceshipContext)
        {
            ISpaceshipMover spaceshipMover = spaceshipContext.SpaceshipMover;
            _spaceshipMovement.Init(spaceshipMover);

            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.color = spaceshipContext.Color;
        }
    }
}
