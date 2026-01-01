using UnityEngine;

namespace Asteroids.Spaceship.Death
{
    public interface IDeathHandler
    {
        void HandleDeath(Spaceship spaceship);
    }
}
