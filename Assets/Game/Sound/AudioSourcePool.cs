using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Pool;

namespace Asteroids.General.Audio
{
    public class AudioSourcePool : MonoBehaviour
    {
        [SerializeField] private Transform _audioSourcesParent;
        private ObjectPool<AudioSource> _objectPool;

        public void PlaySound(AudioClip clip)
        {
            var source = _objectPool.Get();
            source.PlayOneShot(clip);
            ReturnToPool(source, clip.length).Forget();
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
            var go = new GameObject("PooledAudio");
            go.transform.parent = _audioSourcesParent;
            return go.AddComponent<AudioSource>();
        }

        private async UniTask ReturnToPool(AudioSource source, float delay)
        {
            await UniTask.WaitForSeconds(delay);
            _objectPool.Release(source);
        }
    }
}
