using UnityEngine;

namespace Asteroids.Game.Event
{
    public struct GameplayEvent
    {
        public GameplayEventType GameplayEventType;
        public GameObject GameObject;
        public Vector3 PositionVector;
    }
}