using Asteroids.General.Audio;

public class ShotAudioFeedback : MonoBehaviour, IFeedbackReceiver<ShotFiredEvent>
{
    [SerializeField] private AudioCue _audioCue;
    [SerializeField] private AudioEmitter _audioEmitter;

    public void OnEvent(ShotFiredEvent evt)
    {
        _audioEmitter.Play(_audioCue, evt.Position);
    }
}