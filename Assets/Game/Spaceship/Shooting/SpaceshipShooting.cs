using UnityEngine;

public class SpaceshipShooting : MonoBehaviour
{
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
        Debug.Log("Shooting");
    }
}
