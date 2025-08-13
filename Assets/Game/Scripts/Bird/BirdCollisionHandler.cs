using System;
using UnityEngine;

[RequireComponent(typeof(Bird))]
public class BirdCollisionHandler : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioClipDie;
    [SerializeField] private AudioClip _audioClipHit;
    [SerializeField] private AudioClip _audioClipPoint;

    private Bird _bird;

    private void Start()
    {
        _bird = GetComponent<Bird>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out ScaleZone scaleZone))
        {
            _bird.IncreaseScore();
            _audioSource.PlayOneShot(_audioClipPoint);
        }
        else
        {
            _audioSource.PlayOneShot(_audioClipHit);
            _bird.Die();
            _audioSource.PlayOneShot(_audioClipDie);
        }
    }
}