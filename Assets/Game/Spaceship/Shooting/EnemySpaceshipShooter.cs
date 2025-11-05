using UnityEngine;

namespace Asteroids.Spaceship.Shooting
{
    public class EnemySpaceshipShooter : ISpaceshipShooter
    {
        void ISpaceshipShooter.Shoot()
        {
            throw new System.NotImplementedException();
        }

        bool ISpaceshipShooter.ShouldShoot()
        {
            throw new System.NotImplementedException();
        }
    }
}