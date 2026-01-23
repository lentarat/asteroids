public interface IFeedbackReceiver<TEvent>
{
    void OnEvent(TEvent evt);
}