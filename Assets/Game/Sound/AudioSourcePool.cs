using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class AudioSourcePool : MonoBehaviour
{
    private ObjectPool<AudioSource> _pool;

    void Awake()
    {
        _pool = new ObjectPool<AudioSource>(
            createFunc: () => CreateAudioSource(),
            actionOnGet: (obj) => obj.gameObject.SetActive(true),
            actionOnRelease: (obj) => obj.gameObject.SetActive(false),
            actionOnDestroy: (obj) => Destroy(obj.gameObject),
            maxSize: 10
        );
    }

    AudioSource CreateAudioSource()
    {
        var go = new GameObject("PooledAudio");
        return go.AddComponent<AudioSource>();
    }

    public void PlaySound(AudioClip clip, Vector3 position)
    {
        var source = _pool.Get();
        source.transform.position = position;
        source.PlayOneShot(clip);
        StartCoroutine(ReturnToPool(source, clip.length));
    }

    IEnumerator ReturnToPool(AudioSource source, float delay)
    {
        yield return new WaitForSeconds(delay);
        _pool.Release(source);
    }
}
