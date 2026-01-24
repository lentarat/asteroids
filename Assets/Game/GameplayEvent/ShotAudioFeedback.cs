using Asteroids.General.Audio;
using UnityEngine;

namespace Asteroids.Game.Event.Handlers
{
    public class ShotAudioFeedback : MonoBehaviour, IFeedbackReceiver<ShotFiredEvent>
    {
        [SerializeField] private AudioClip _audioClip;
        [SerializeField] private AudioEmitter _audioEmitter;
        [SerializeField] private float _pitch;

        public void OnEvent(ShotFiredEvent shotFiredEvent)
        {
            _audioEmitter.PlaySound(_audioClip, _pitch);
        }
    }
}