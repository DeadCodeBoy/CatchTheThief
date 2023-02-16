using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]

public class AlarmZone : MonoBehaviour
{
    [SerializeField] private AudioClip _sound;
    [SerializeField] private float _volumeStep;
    [SerializeField] private float _minVolume;
    [SerializeField] private float _maxVolume;

    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void Begin()
    {
        StartCoroutine(VolumeUp());
    }
   
    private IEnumerator VolumeUp()
    {
        _audioSource.PlayOneShot(_sound, _audioSource.volume);
        _audioSource.volume += _volumeStep;
        
        if (_audioSource.volume == _maxVolume)
        {
            while (_audioSource.volume > _minVolume)
            {
                _audioSource.volume -= _volumeStep;
                 yield return new WaitForSeconds(1.5f);
            }
        StopCoroutine(VolumeUp());
        }
    }
}
