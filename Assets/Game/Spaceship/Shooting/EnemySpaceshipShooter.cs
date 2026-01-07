using UnityEngine;

namespace Asteroids.Spaceship.Shooting
{
    public class EnemySpaceshipShooter : ISpaceshipShooter
    {
        bool ISpaceshipShooter.ShouldShoot()
        {
            return true;
        }
    }
}