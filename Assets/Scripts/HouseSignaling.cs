using System.Collections;
using UnityEngine;

public class HouseSignaling : MonoBehaviour
{
    private const int MaxVolume = 1;
    private const int MinVolume = 0;

    [SerializeField] private HouseDetectionSystem _detectionSystem;
    [SerializeField] private AudioSource _signaling;
    [SerializeField, Min(0)] private int _timeChangeVolume;
    [SerializeField, Range(0, 1)] private float _volumeRange;

    private Coroutine _coroutine;
    private WaitForSeconds _wait;
    private float _currentVolume = MinVolume;

    private void Start()
    {
        _signaling.loop = true;
    }

    private void OnEnable()
    {
        _detectionSystem.RobberEntered += ActivateSound;
        _detectionSystem.RobberExited += DisableSound;
    }

    private void OnDisable()
    {
        _detectionSystem.RobberEntered -= ActivateSound;
        _detectionSystem.RobberExited -= DisableSound;
    }

    private void ActivateSound()
    {
        _signaling.Play();

        if (_coroutine != null)
            StopCoroutine(_coroutine);
        
        _coroutine = StartCoroutine(ChangingVolume(MaxVolume));
    }

    private void DisableSound()
    {
        StopCoroutine(_coroutine);
        _coroutine = StartCoroutine(ChangingVolume(MinVolume));
    }

    private IEnumerator ChangingVolume(float targetVolume)
    {
        _wait = new WaitForSeconds(_timeChangeVolume);

        if (_currentVolume == MinVolume)
            _currentVolume = _volumeRange;

        while (_currentVolume != targetVolume)
        {
            _signaling.volume = _currentVolume;
            _currentVolume = Mathf.MoveTowards(_currentVolume, targetVolume, _volumeRange);

            yield return _wait;
        }

        if (_currentVolume == MinVolume)
            _signaling.Stop();

        yield break;
    }
}
