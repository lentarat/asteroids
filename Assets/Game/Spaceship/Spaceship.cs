using Asteroids.Spaceship.Movement;
using Asteroids.Spaceship.Shooting;
using UnityEngine;
using Zenject;

namespace Asteroids.Spaceship
{
    public class Spaceship : MonoBehaviour, IDamageable
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

        private void OnTriggerEnter2D(Collider2D other)
        {
            Destroy(gameObject);
        }

        void IDamageable.ApplyDamage(float damage)
        {
            Destroy(gameObject);
        }
    }
}
