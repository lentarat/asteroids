using Asteroids.Spaceship;
using UnityEngine;

namespace Asteroids.Signals
{
    public struct PlayerDestroyedSignal
    {
        public ISpaceship Spaceship { get; private set; }

        public PlayerDestroyedSignal(ISpaceship spaceship)
        {
            Spaceship = spaceship;
        }
    }
}