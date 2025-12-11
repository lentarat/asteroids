using UnityEngine;

namespace Asteroids.Signals
{
    public class PlayerDestroyedSignal
    {
        public Spaceship.Spaceship PlayerSpaceship { get; set; }
    }
}