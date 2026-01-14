using Asteroids.General.Audio;
using Asteroids.Spaceship.Movement;
using Asteroids.Spaceship.Shooting;
using UnityEngine;

namespace Asteroids.Spaceship.Shooting
{
    public class SpaceshipShooting : MonoBehaviour
    {
        [SerializeField] private SpaceshipWeaponSO _spaceshipWeaponSO;
        [SerializeField] private SpaceshipProjectileSO _spaceshipProjectileSO;
        [SerializeField] private SpaceshipProjectile _spaceshipBullet;
        [SerializeField] private AudioEmitter _audioEmitter; 
        [SerializeField] private AudioClip _audioClip;
        [SerializeField, Range(0f, 0.5f)] private float _randomPitchDeviation;

        private float _lastShotTime;
        private Transform _projectilesParent;
        private Spaceship _parentSpaceship;
        private ISpaceshipShooter _spaceshipShooter;

        public void Init(Transform projectilesParent, Spaceship parentSpaceship)
        {
            _projectilesParent = projectilesParent;
            _parentSpaceship = parentSpaceship;
        }

        public void InitializeContext(ISpaceshipShooter spaceshipShooter)
        {
            _spaceshipShooter = spaceshipShooter;
        }

        private void Update()
        {
            bool shouldShoot = _spaceshipShooter.ShouldShoot();
            if (shouldShoot)
            {
                Shoot();
            }
        }

        private void Shoot()
        {
            bool hasShootingIntervalPassed = HasShootingIntervalPassed();
            if (hasShootingIntervalPassed)
            {
                SpaceshipProjectile spaceshipProjectile = 
                    Instantiate(_spaceshipBullet, transform.position, Quaternion.identity, _projectilesParent);

                Sprite sprite = _spaceshipProjectileSO.ProjectileSprite;
                Vector2 direction = transform.up;
                float speed = _spaceshipWeaponSO.ProjectileSpeed;
                float damage = _spaceshipProjectileSO.Damage;
                int lifetimeMS = _spaceshipProjectileSO.LifetimeMS;

                spaceshipProjectile.Init(_parentSpaceship, sprite, direction, speed, damage, lifetimeMS);

                _lastShotTime = Time.time;
            }
        }

        private bool HasShootingIntervalPassed()
        {
            bool hasShootingIntervalPassed =
                Time.time > _lastShotTime + _spaceshipWeaponSO.Interval;

            return hasShootingIntervalPassed;
        }

        private void PlayShootingSound()
        {
            float randomPitch = Random.Range(1f - _randomPitchDeviation, 1f + _randomPitchDeviation);
            _audioEmitter.PlaySound(_audioClip, randomPitch);
        }
    }
}
