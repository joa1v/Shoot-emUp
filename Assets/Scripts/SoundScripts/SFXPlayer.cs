using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SFXPlayer : MonoBehaviour
{
    private AudioSource audioSource;
    public SoundBank soundBank;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

    }
    public void PlayShootSFX()
    {
        if (Time.timeScale > 0)
        {
            audioSource.clip = soundBank.shootSFX.audioClips[Random.Range(0, soundBank.shootSFX.audioClips.Length)];
            audioSource.volume = soundBank.shootSFX.volume;
            audioSource.Play();
        }
    }

    public void PlayPowerUPSFX()
    {
        if (Time.timeScale > 0)
        {
            audioSource.clip = soundBank.powerUpSFX.audioClips[Random.Range(0, soundBank.powerUpSFX.audioClips.Length)];
            audioSource.volume = soundBank.powerUpSFX.volume;
            audioSource.Play();
        }
    }

    public void PlayDropSFX()
    {
        if (Time.timeScale > 0)
        {
            audioSource.clip = soundBank.dropSFX.audioClips[Random.Range(0, soundBank.dropSFX.audioClips.Length)];
            audioSource.volume = soundBank.dropSFX.volume;
            audioSource.Play();
        }
    }

    public void PlayExplosionSFX()
    {
        if (Time.timeScale > 0)
        {
            AudioSource.PlayClipAtPoint(soundBank.explosionSFX.audioClips[Random.Range(0, soundBank.explosionSFX.audioClips.Length)], transform.position, soundBank.explosionSFX.volume);
        }
    }
}
