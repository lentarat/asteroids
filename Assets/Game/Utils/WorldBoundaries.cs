using UnityEngine;

namespace Asteroids.Utils
{
    public struct WorldBoundaries
    {
        public readonly Vector2 UpperVector { get; }
        public readonly Vector2 RightVector { get; }
        public readonly Vector2 LowerVector { get; }
        public readonly Vector2 LeftVector { get; }

        public WorldBoundaries(Vector2 upperVector, Vector2 rightVector, Vector2 lowerVector, Vector2 leftVector)
        {
            UpperVector = upperVector;
            RightVector = rightVector;
            LowerVector = lowerVector;
            LeftVector = leftVector;
        }
    }
}