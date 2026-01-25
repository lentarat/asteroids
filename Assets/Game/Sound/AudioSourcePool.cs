using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Pool;

namespace Asteroids.General.Audio
{
    public class AudioSourcePool : MonoBehaviour
    {
        [SerializeField] private Transform _audioSourcesParent;
        private ObjectPool<AudioSource> _objectPool;

        public void PlaySound(AudioClip clip, float volume = 1f, float pitch = 1f)
        {
            AudioSource audioSource = _objectPool.Get();

            audioSource.pitch = pitch;
            audioSource.PlayOneShot(clip);

            ReturnToPool(audioSource, clip.length).Forget();
        }

        private void Awake()
        {
            _objectPool = new ObjectPool<AudioSource>(
                createFunc: () => CreateAudioSource(),
                actionOnGet: (obj) => obj.gameObject.SetActive(true),
                actionOnRelease: (obj) => obj.gameObject.SetActive(false),
                actionOnDestroy: (obj) => Destroy(obj.gameObject),
                maxSize: 10
            );
        }

        private AudioSource CreateAudioSource()
        {
            GameObject gameObject = new GameObject("PooledAudio");
            gameObject.transform.parent = transform;
            AudioSource audioSource = gameObject.AddComponent<AudioSource>();
            return audioSource;
        }

        private async UniTask ReturnToPool(AudioSource source, float delay)
        {
            await UniTask.WaitForSeconds(delay);
            _objectPool.Release(source);
        }
    }
}
