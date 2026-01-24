namespace Asteroids.Game.Event.Handlers
{
    public interface IFeedbackReceiver<TEvent>
    {
        void OnEvent(TEvent evt);
    }
}