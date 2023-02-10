using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AlarmZone : MonoBehaviour
{
    [SerializeField] private AudioClip _sound;
    [SerializeField] private float _volumeStep;

    private AudioSource _audioSource;

    private void Update()
    {
       _audioSource.volume -= _volumeStep;
    }

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerMovement>(out PlayerMovement player))
        {
            _audioSource.PlayOneShot(_sound, _audioSource.volume);
            _audioSource.volume += Time.deltaTime;
        }
    }
}
