using Asteroids.Spaceship.Movement;
using UnityEngine;

public class SpaceshipShooting : MonoBehaviour
{
    private ISpaceshipShooter _spaceshipShooter;
    private SpaceshipShootingSO _spaceshipShootingSO;

    public void Init(ISpaceshipShooter spaceshipShooter, SpaceshipShootingSO spaceshipShootingSO)
    { 
        _spaceshipShooter = spaceshipShooter;
        _spaceshipShootingSO = spaceshipShootingSO;
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
        Debug.Log("Shooting");
    }
}
