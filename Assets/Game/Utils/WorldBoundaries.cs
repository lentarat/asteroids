using UnityEngine;

namespace Asteroids.Utils
{
    public struct WorldBoundaries
    {
        public Vector2 RightUpper { get; private set; }
        public Vector2 RightLower { get; private set; }
        public Vector2 LeftUpper { get; private set; }
        public Vector2 LeftLower { get; private set; }

        public Vector2 this[int index]
        {
            get
            { 
                return index switch
                { 
                    0 => RightUpper,
                    1 => RightLower,
                    2 => LeftUpper,
                    3 => LeftLower,
                    _ => throw new System.IndexOutOfRangeException("Invalid world boundaries index.")
                };
            }
        }

        public static Vector2 GetRandomPositionBeyondBoundaries()
        {
            WorldBoundaries worldBoundaries = GetWorldBoundaries();
            return Vector2.zero;
        }

        private static WorldBoundaries GetWorldBoundaries()
        {
            Camera camera = Camera.main;

            Vector3 rightUpperScreenPosition = new Vector3(Screen.width, Screen.height, 0f);
            Vector3 rightLowerScreenPosition = new Vector3(Screen.width, 0f, 0f);
            Vector3 leftUpperScreenPosition = new Vector3(0f, Screen.height, 0f);
            Vector3 leftLowerScreenPosition = new Vector3(0f, 0f, 0f);

            Vector2 rightUpperWorldPosition = camera.ScreenToWorldPoint(rightUpperScreenPosition);
            Vector2 rightLowerWorldPosition = camera.ScreenToWorldPoint(rightLowerScreenPosition);
            Vector2 leftUpperWorldPosition = camera.ScreenToWorldPoint(leftUpperScreenPosition);
            Vector2 leftLowerWorldPosition = camera.ScreenToWorldPoint(leftLowerScreenPosition);

            WorldBoundaries worldBoundaries = new WorldBoundaries()
            {
                RightUpper = rightUpperWorldPosition,
                RightLower = rightLowerWorldPosition,
                LeftUpper = leftUpperWorldPosition,
                LeftLower = leftLowerWorldPosition,
            };

            return worldBoundaries;
        }
    }
}