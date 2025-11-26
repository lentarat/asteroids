using Asteroids.Spaceship.Movement;
using UnityEngine;
using Zenject;

namespace Asteroids.Spaceship
{
    public class Spaceship : MonoBehaviour
    {
        [SerializeField] private SpaceshipMovement _spaceshipMovement;
        [SerializeField] private SpaceshipShooting _spaceshipShooting;

        public void InitializeSpaceship(SpaceshipContext spaceshipContext)
        {
            ISpaceshipMover spaceshipMover = spaceshipContext.SpaceshipMover;
            ISpaceshipShooter spaceshipShooter = spaceshipContext.SpaceshipShooter;
            _spaceshipMovement.Init(spaceshipMover);
            _spaceshipShooting.Init(spaceshipShooter);

            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.color = spaceshipContext.Color;
        }

        private void OnTriggerEnter(Collider other)
        {
            Destroy(gameObject);
        }
    }
}
