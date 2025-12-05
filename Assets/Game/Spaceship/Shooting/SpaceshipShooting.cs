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

        private float _lastShotTime;
        private ISpaceshipShooter _spaceshipShooter;

        public void Init(ISpaceshipShooter spaceshipShooter)
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
                    Instantiate(_spaceshipBullet, transform.position, Quaternion.identity);

                Sprite sprite = _spaceshipProjectileSO.ProjectileSprite;
                Vector2 direction = transform.up;
                float speed = _spaceshipWeaponSO.ProjectileSpeed;
                float damage = _spaceshipProjectileSO.Damage;

                spaceshipProjectile.Init(sprite, direction, speed, damage);

                _lastShotTime = Time.time;
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
