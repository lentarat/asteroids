using Asteroids.Signals;
using Asteroids.Spaceship.Death;
using Asteroids.Spaceship.Movement;
using Asteroids.Spaceship.Shooting;
using System;
using UnityEngine;
using Zenject;

namespace Asteroids.Spaceship
{
    public class Spaceship : MonoBehaviour, ISpaceship, IDamageable
    {
        [SerializeField] private SpaceshipShooting _spaceshipShooting;
        [SerializeField] private SpaceshipMovement _spaceshipMovement;

        private IDeathHandler _deathHandler;

        public void InitializeSpaceship(SpaceshipContext spaceshipContext)
        {
            ISpaceshipMover spaceshipMover = spaceshipContext.SpaceshipMover;
            ISpaceshipShooter spaceshipShooter = spaceshipContext.SpaceshipShooter;
            _spaceshipMovement.Init(spaceshipMover);
            _spaceshipShooting.Init(spaceshipShooter, this);

            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.color = spaceshipContext.Color;

            _deathHandler = spaceshipContext.DeathHandler;
        }

        private void OnTriggerEnter2D(Collider2D collider)
        {
            IDamageable damageable = collider.GetComponentInParent<IDamageable>(true);

            if (damageable != null)
            {
                _deathHandler.HandleDeath(this);
            }
        }

        void ISpaceship.SetActive(bool isActive)
        {
            gameObject.SetActive(isActive);
        }

        void ISpaceship.ResetRigidbody()
        {
            _spaceshipMovement.ResetRigidbody();
        }

        void ISpaceship.Die()
        {
            Destroy(gameObject);
        }

        void IDamageable.ApplyDamage(float damage)
        {
            _deathHandler.HandleDeath(this);
        }
    }
}
