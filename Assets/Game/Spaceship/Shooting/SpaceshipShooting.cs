using Asteroids.Spaceship.Movement;
using UnityEngine;

public class SpaceshipShooting : MonoBehaviour
{
    [SerializeField] private SpaceshipShootingSO _spaceshipShootingSO;
    
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
        //Instantiate( _spaceshipShootingSO.ProjectileSprite)
    }
}
