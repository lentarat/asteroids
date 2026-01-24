using UnityEngine;

namespace Asteroids.Game.Event
{
    public struct ShotFiredEvent
    {
        public Vector3 Position { get; set; }
        public Vector2 Direction { get; set; }
    }
}