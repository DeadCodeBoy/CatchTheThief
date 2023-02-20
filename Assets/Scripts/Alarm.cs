using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioClip _sound;
    [SerializeField] private float _volumeStep;
    [SerializeField] private float _minVolume;
    [SerializeField] private float _maxVolume;

    private AudioSource _audioSource;
    private bool _isExit = false;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void Begin()
    {
        StartCoroutine(VolumeChange());
    }

    public void End()
    {
        _isExit = true;
    }

    private IEnumerator VolumeChange()
    {
        var waitForSeconds = new WaitForSeconds(2f);
        _audioSource.PlayOneShot(_sound, _audioSource.volume);
       
        while (_isExit == false)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _maxVolume, _volumeStep);
            yield return waitForSeconds;
        }
        if (_isExit == true)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _minVolume, _volumeStep);
            yield return waitForSeconds;
        }
    }
}
