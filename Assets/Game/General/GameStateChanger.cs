using UnityEngine;

namespace Asteroids.General.GameState
{
    public static class GameStateChanger
    {
        private static GameState _currentGameState;

        public static void SetNormal()
        { 
            _currentGameState = GameState.Normal;
            Time.timeScale = 1f;
        }

        public static void SetPaused()
        {
            _currentGameState = GameState.Paused;
            Time.timeScale = 0f;
        }
    }
}
