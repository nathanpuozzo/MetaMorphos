using System.Collections;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource = null;
    [SerializeField] private AssetReference[] _soundtracks = null;
    private int _playingSoundtrack = 0;

    IEnumerator Start()
    {
        while (true)
        {
            var currentOperationHandle = _soundtracks[_playingSoundtrack].LoadAssetAsync<AudioClip>();
            yield return currentOperationHandle;
            var newAudioClip = currentOperationHandle.Result;
            _audioSource.clip = newAudioClip;
            _audioSource.Play();

            yield return new WaitUntil(() => _audioSource.isPlaying == false);

            _audioSource.clip = null;
            Addressables.Release(currentOperationHandle);

            _playingSoundtrack = (_playingSoundtrack + 1) % _soundtracks.Length;
        }
    }
}
