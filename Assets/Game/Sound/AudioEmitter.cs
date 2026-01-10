using Asteroids.General;
using UnityEngine;
using Zenject;

namespace Asteroids.General.Audio
{
    public class AudioEmitter : MonoBehaviour
    {
        private AudioSourcePool _audioSourcePool;

        [Inject]
        private void Construct(AudioSourcePool audioSourcePool)
        {
            Debug.Log(Time.time);
            _audioSourcePool = audioSourcePool;
        }

        public void PlaySound(AudioClip audioClip)
        {
            _audioSourcePool.PlaySound(audioClip);
        }
    }
}