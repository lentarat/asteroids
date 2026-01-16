using Asteroids.General.Audio;
using UnityEngine;

public class AudioService : IAudioService
{
    private readonly AudioEmitter _emitter;

   public AudioService(AudioEmitter emitter)
    {
        _emitter = emitter;
    }

    public void Play(AudioDefinitionSO definition, Vector3 position)
    {
        if (definition == null || definition.Clip == null || _emitter == null) return;

        float pitch = Random.Range(1f - definition.RandomPitchDeviation, 1f + definition.RandomPitchDeviation);
       _emitter.PlaySound(definition.Clip, pitch);
    }
}