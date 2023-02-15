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

    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private IEnumerator VolumeUp()
    {
        _audioSource.PlayOneShot(_sound, _audioSource.volume);
        _audioSource.volume += _volumeStep;
        yield return null;
    }

    private IEnumerator VolumeDown()
    {
        while (_audioSource.volume > _minVolume)
        {
            _audioSource.volume -= _volumeStep;
            yield return null;
        }
        StopCoroutine(VolumeDown());
    }
   
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerMovement>(out PlayerMovement player))
        {
            StartCoroutine(VolumeUp());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerMovement>(out PlayerMovement player))
        {
            StopCoroutine(VolumeUp());
            StartCoroutine(VolumeDown());
        }
    }
}
