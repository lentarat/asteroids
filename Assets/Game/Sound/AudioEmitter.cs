using Asteroids.General;
using UnityEngine;
using Zenject;

namespace Asteroids.General.Audio
{
    public class AudioEmitter : MonoBehaviour
    {
        private AudioSourcePool _audioSourcePool;

        public void Init(AudioSourcePool audioSourcePool)
        {
            _audioSourcePool = audioSourcePool;
        }

        public void PlaySound(AudioClip audioClip, float pitch)
        {
            _audioSourcePool.PlaySound(audioClip, pitch: pitch);
        }
    }
}