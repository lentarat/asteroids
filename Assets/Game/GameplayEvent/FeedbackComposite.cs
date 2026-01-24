using UnityEngine;

namespace Asteroids.Game.Event.Handlers
{
    public class FeedbackComposite<T> : MonoBehaviour, IFeedbackReceiver<T>
    {
        private IFeedbackReceiver<T>[] _receivers;

        private void Awake()
        {
            _receivers = GetComponents<IFeedbackReceiver<T>>();
        }

        public void OnEvent(T @event)
        {
            foreach (var receiver in _receivers)
                receiver.OnEvent(@event);
        }
    }
}