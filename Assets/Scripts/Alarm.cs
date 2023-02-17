using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioClip _sound;
    [SerializeField] private float _volumeStep;
    [SerializeField] private float _minVolume;
    [SerializeField] private float _maxVolume;

    private AudioSource _audioSource;
    private bool IsExit = false;
    
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void Begin()
    {
        StartCoroutine(VolumeUp());
    }
    
    public void End()
    {
        IsExit = true;
    }

    private IEnumerator VolumeUp()
    {
        var waitForSeconds = new WaitForSeconds(2f);
        _audioSource.PlayOneShot(_sound, _audioSource.volume);
        _audioSource.volume += Mathf.MoveTowards(_minVolume, _maxVolume, _volumeStep);
        yield return waitForSeconds;
       
        if (IsExit==true)
            {
             _audioSource.volume -= Mathf.MoveTowards(_minVolume, _maxVolume, _volumeStep);
             yield return waitForSeconds;
            }
        StopCoroutine(VolumeUp());
    }
}
