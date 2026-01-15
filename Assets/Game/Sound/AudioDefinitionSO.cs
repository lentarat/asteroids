using UnityEngine;

[CreateAssetMenu(menuName = "Audio/AudioDefinition")]
public class AudioDefinitionSO : ScriptableObject
{
    [SerializeField] private AudioClip _audioClip;
    public AudioClip AudioClip => _audioClip;
    [SerializeField, Range(0f, 1f)] private float _volume = 1f;
    public float Volume => _volume;
    [Range(0f, 0.5f)] private float _randomPitchDeviation = 0.05f;
    public float RandomPitchDeviation => _randomPitchDeviation;
}