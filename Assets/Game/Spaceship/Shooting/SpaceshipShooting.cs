using Asteroids.Spaceship.Movement;
using UnityEngine;

public class SpaceshipShooting : MonoBehaviour
{
    [SerializeField] private SpaceshipShootingSO _spaceshipShootingSO;
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
        if(hasShootingIntervalPassed)
        {
            SpaceshipProjectile spaceshipProjectile = Instantiate(_spaceshipBullet);
            Sprite sprite = _spaceshipShootingSO.ProjectileSprite;
            Vector2 direction = transform.up;
            float speed = _spaceshipShootingSO.

            _lastShotTime = Time.time;
        }
    }

    private bool HasShootingIntervalPassed()
    {
        bool hasShootingIntervalPassed =
            Time.time > _lastShotTime + _spaceshipShootingSO.Interval;
        return hasShootingIntervalPassed;
    }
}
