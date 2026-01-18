using UnityEngine;

namespace Asteroids.General.Audio
{
    public interface IAudioService
    {
        void Play(AudioDefinitionSO definition, Vector3 position);
    }
}