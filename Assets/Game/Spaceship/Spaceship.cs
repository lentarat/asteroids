using Asteroids.Spaceship.Movement;
using Asteroids.Spaceship.Shooting;
using System;
using UnityEngine;
using Zenject;

namespace Asteroids.Spaceship
{
    public class Spaceship : MonoBehaviour, IDamageable
    {
        [SerializeField] private SpaceshipMovement _spaceshipMovement;
        [SerializeField] private SpaceshipShooting _spaceshipShooting;

        public event Action OnDestroyed;

        public void InitializeSpaceship(SpaceshipContext spaceshipContext)
        {
            ISpaceshipMover spaceshipMover = spaceshipContext.SpaceshipMover;
            ISpaceshipShooter spaceshipShooter = spaceshipContext.SpaceshipShooter;
            _spaceshipMovement.Init(spaceshipMover);
            _spaceshipShooting.Init(spaceshipShooter, this);

            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.color = spaceshipContext.Color;
        }

        private void OnTriggerEnter2D(Collider2D collider)
        {
            IDamageable damageable = collider.GetComponentInParent<IDamageable>();

            if (damageable != null)
            {
                OnDestroyed?.Invoke();
            }
        }

        //private void DestroySpaceship()
        //{
        //    OnDestroyed?.Invoke();
        //    Destroy(gameObject);
        //}

        void IDamageable.ApplyDamage(float damage)
        {
            OnDestroyed?.Invoke();
        }
    }
}
