using Asteroids.General.Audio;
using Asteroids.Signals;
using Asteroids.Spaceship.Death;
using Asteroids.Spaceship.Movement;
using Asteroids.Spaceship.Shooting;
using Cysharp.Threading.Tasks;
using System;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Asteroids.Spaceship
{
    public class Spaceship : MonoBehaviour, ISpaceship, IDamageable
    {
        [SerializeField] private SpaceshipShooting _spaceshipShooting;
        [SerializeField] private SpaceshipMovement _spaceshipMovement;
        [SerializeField] private AudioEmitter _audioEmitter;

        private IDeathHandler _deathHandler;

        public void Init(AudioSourcePool audioSourcePool, Transform projectilesParent)
        {
            _audioEmitter.Init(audioSourcePool);
            _spaceshipShooting.Init(projectilesParent, this);
        }

        public void InitializeContext(SpaceshipContext spaceshipContext)
        {
            ISpaceshipMover spaceshipMover = spaceshipContext.SpaceshipMover;
            ISpaceshipShooter spaceshipShooter = spaceshipContext.SpaceshipShooter;
            _spaceshipMovement.InitializeContext(spaceshipMover);
            _spaceshipShooting.InitializeContext(spaceshipShooter);

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

        void ISpaceship.SetActiveAfterFixedUpdate(bool isActive)
        {
            SetActiveAfterFixedUpdateAsync(isActive).Forget();
        }

        private async UniTask SetActiveAfterFixedUpdateAsync(bool isActive)
        {
            await UniTask.WaitForFixedUpdate();
            gameObject.SetActive(isActive);
        }

        void ISpaceship.ResetMovement()
        {
            _spaceshipMovement.ResetMovement();
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
