using Asteroids.Signals;
using Asteroids.Spaceship.Death;
using Asteroids.Spaceship.Movement;
using Asteroids.Spaceship.Shooting;
using System;
using UnityEngine;
using Zenject;

namespace Asteroids.Spaceship
{
    public class Spaceship : MonoBehaviour, IDamageable
    {
        [SerializeField] private SpaceshipShooting _spaceshipShooting;
        [SerializeField] private SpaceshipMovement _spaceshipMovement;

        public SpaceshipType SpaceshipType { get; private set; }

        private IDeathHandler _deathHandler;

        public void InitializeSpaceship(SpaceshipContext spaceshipContext)
        {
            SpaceshipType = spaceshipContext.SpaceshipType;

            ISpaceshipMover spaceshipMover = spaceshipContext.SpaceshipMover;
            ISpaceshipShooter spaceshipShooter = spaceshipContext.SpaceshipShooter;
            _spaceshipMovement.Init(spaceshipMover);
            _spaceshipShooting.Init(spaceshipShooter, this);

            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.color = spaceshipContext.Color;

            _deathHandler = spaceshipContext.DeathHandler;
        }

        public void SetActive(bool isActive)
        { 
            gameObject.SetActive(isActive);
        }

        public void ResetRigidbody()
        {
            _spaceshipMovement.ResetRigidbody();
        }

        private void OnTriggerEnter2D(Collider2D collider)
        {
            IDamageable damageable = collider.GetComponentInParent<IDamageable>(true);

            if (damageable != null)
            {
                HandleDeath();
            }
        }

        private void HandleDeath()
        {
            _deathHandler.HandleDeath(this);
        }

        void IDamageable.ApplyDamage(float damage)
        {
            HandleDeath();
        }
    }
}
