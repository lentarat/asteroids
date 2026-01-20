using System;
using UnityEngine;
using Asteroids.Game.Event;

namespace Asteroids.Game.Event
{
    public class GameplayEventDispatcher : MonoBehaviour
    {
        public event Action<GameplayEvent> OnEvent;
        public void Publish(GameplayEvent e) => OnEvent?.Invoke(e);
    }
}