using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseSignaling : MonoBehaviour
{
    private const int MaxVolume = 1;
    private const int MinVolume = 0;

    [SerializeField] private HouseDetectionSystem _detectionSystem;
    [SerializeField] private AudioSource _signaling;
    [SerializeField, Min(0)] private int _timeChangeVolume;
    [SerializeField, Range(0, 1)] private float _volumeRange;

    private WaitForSeconds _wait;
    private float _currentVolume = 0;
    private float _targetVolume;

    private void Start()
    {
        _signaling.loop = true;
    }

    private void OnEnable()
    {
        _detectionSystem.OnRobberEntered += ActivateSound;
        _detectionSystem.OnRobberExited += DisableSound;
    }

    private void OnDisable()
    {
        _detectionSystem.OnRobberEntered -= ActivateSound;
        _detectionSystem.OnRobberExited -= DisableSound;
    }

    private void ActivateSound()
    {
        _wait = new WaitForSeconds(_timeChangeVolume);

        _targetVolume = MaxVolume;

        _signaling.Play();

        StartCoroutine(ChangingVolume());
    }

    private void DisableSound()
    {
        _targetVolume = MinVolume;
    }

    private IEnumerator ChangingVolume()
    {
        _currentVolume += _volumeRange;

        while (_currentVolume != MinVolume)
        {
            _signaling.volume = _currentVolume;
            _currentVolume = Mathf.MoveTowards(_currentVolume, _targetVolume, _volumeRange);

            yield return _wait;
        }

        _signaling.Stop();

        yield break;
    }
}
