using Asteroids.Signals;
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
        public SpaceshipMovement SpaceshipMovement => _spaceshipMovement;

        public SpaceshipType SpaceshipType { get; private set; }
        private SignalBus _signalBus;

        public void InitializeSpaceship(SpaceshipContext spaceshipContext, SignalBus signalBus)
        {
            SpaceshipType = spaceshipContext.SpaceshipType;

            ISpaceshipMover spaceshipMover = spaceshipContext.SpaceshipMover;
            ISpaceshipShooter spaceshipShooter = spaceshipContext.SpaceshipShooter;
            _spaceshipMovement.Init(spaceshipMover);
            _spaceshipShooting.Init(spaceshipShooter, this);

            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.color = spaceshipContext.Color;

            _signalBus = signalBus;
        }

        private void OnTriggerEnter2D(Collider2D collider)
        {
            IDamageable damageable = collider.GetComponentInParent<IDamageable>(true);

            if (damageable != null)
            {
                DestroySpaceshipSignal();
            }
        }

        private void DestroySpaceshipSignal()
        {
            SpaceshipDestroyedSignal spaceshipDestroyedSignal = new(this);
            _signalBus.Fire(spaceshipDestroyedSignal);
        }

        void IDamageable.ApplyDamage(float damage)
        {
            DestroySpaceshipSignal();
        }
    }
}
