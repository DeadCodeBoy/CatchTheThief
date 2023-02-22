using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioClip _sound;
    [SerializeField] private float _volumeStep;
    
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void Enter()
    {
        StopCoroutine(VolumeChange(0));
        StartCoroutine(VolumeChange(1f));
    }

    public void Exit()
    {
        StopCoroutine(VolumeChange(1f));
        StartCoroutine(VolumeChange(0));
    }

    private IEnumerator VolumeChange(float targetVolume)
    {
        var waitForSeconds = new WaitForSeconds(targetVolume);
        _audioSource.PlayOneShot(_sound, _audioSource.volume);

        while (_audioSource.volume != targetVolume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, targetVolume, _volumeStep);
            yield return waitForSeconds;
        }
    }
}
