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

        private float _lastShotTime;
        private Spaceship _parentSpaceship;
        private ISpaceshipShooter _spaceshipShooter;

        public void Init(ISpaceshipShooter spaceshipShooter, Spaceship parentSpaceship)
        {
            _spaceshipShooter = spaceshipShooter;
            _parentSpaceship = parentSpaceship;
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
                    Instantiate(_spaceshipBullet, transform.position, Quaternion.identity);

                Sprite sprite = _spaceshipProjectileSO.ProjectileSprite;
                Vector2 direction = transform.up;
                float speed = _spaceshipWeaponSO.ProjectileSpeed;
                float damage = _spaceshipProjectileSO.Damage;
                int lifetimeMS = _spaceshipProjectileSO.LifetimeMS;

                spaceshipProjectile.Init(_parentSpaceship, sprite, direction, speed, damage, lifetimeMS);

                _lastShotTime = Time.time;

                _audioEmitter.PlaySound(_audioClip);
            }
        }

        private bool HasShootingIntervalPassed()
        {
            bool hasShootingIntervalPassed =
                Time.time > _lastShotTime + _spaceshipWeaponSO.Interval;
            return hasShootingIntervalPassed;
        }
    }
}
