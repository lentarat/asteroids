using UnityEngine;

namespace Asteroids.Utils
{
    public static class WorldBoundaryUtils
    {
        private const float OffsetMultiplier = 0.15f;

        private enum ScreenSide 
        {
            Upper, 
            Right,
            Lower,
            Left 
        }

        public static WorldBoundaries GetWorldBoundaries(Camera camera)
        {
            var upper = camera.ScreenToWorldPoint(new Vector3(Screen.width * 0.5f, Screen.height, 0f));
            var right = camera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height * 0.5f, 0f));
            var lower = camera.ScreenToWorldPoint(new Vector3(Screen.width * 0.5f, 0f, 0f));
            var left = camera.ScreenToWorldPoint(new Vector3(0f, Screen.height * 0.5f, 0f));

            WorldBoundaries worldBoundaries = new WorldBoundaries(upper, right, lower, left);
            return worldBoundaries;
        }

        public static Vector2 GetRandomPositionBeyondBoundaries(WorldBoundaries worldBoundaries)
        {
            var side = (ScreenSide)Random.Range(0, 4);
            return side switch
            {
                ScreenSide.Upper => RandomUpper(worldBoundaries),
                ScreenSide.Right => RandomRight(worldBoundaries),
                ScreenSide.Lower => RandomLower(worldBoundaries),
                ScreenSide.Left => RandomLeft(worldBoundaries),
                _ => throw new System.ArgumentOutOfRangeException()
            };
        }

        private static Vector2 RandomUpper(WorldBoundaries worldBoundaries)
        {
            float y = worldBoundaries.UpperVector.y
                + (worldBoundaries.UpperVector.y - worldBoundaries.LowerVector.y)
                * OffsetMultiplier;
            float x = Random.Range(worldBoundaries.LeftVector.x, worldBoundaries.RightVector.x);

            return new Vector2(x, y);
        }

        private static Vector2 RandomRight(WorldBoundaries worldBoundaries)
        {
            float x = worldBoundaries.RightVector.x
                + (worldBoundaries.RightVector.x - worldBoundaries.LeftVector.x)
                * OffsetMultiplier;
            float y = Random.Range(worldBoundaries.LowerVector.y, worldBoundaries.UpperVector.y);
            
            return new Vector2(x, y);
        }

        private static Vector2 RandomLower(WorldBoundaries worldBoundaries)
        {
            float y = worldBoundaries.LowerVector.y 
                - (worldBoundaries.UpperVector.y - worldBoundaries.LowerVector.y) 
                * OffsetMultiplier;
            float x = Random.Range(worldBoundaries.LeftVector.x, worldBoundaries.RightVector.x);
            
            return new Vector2(x, y);
        }

        private static Vector2 RandomLeft(WorldBoundaries worldBoundaries)
        {
            float x = worldBoundaries.LeftVector.x 
                - (worldBoundaries.RightVector.x - worldBoundaries.LeftVector.x)
                * OffsetMultiplier;
            float y = Random.Range(worldBoundaries.LowerVector.y, worldBoundaries.UpperVector.y);
            
            return new Vector2(x, y);
        }
    }
}