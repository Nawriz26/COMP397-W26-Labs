using System;
using System.Collections;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioClip backgroundMusic;
    [SerializeField] private AudioClip jumpSFX;
    [SerializeField] private AudioClip deathSFX;

    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxSource;

    public static object Instance { get; internal set; }

    private IEnumerator Start()
    {
        Debug.Log("AudioController Start called");
        yield return new WaitForSeconds(4f); // Wait for 4 seconds to ensure all components are initialized
        Debug.Log("AudioController Start after 4 sec");
        PlayBgMusic();
    }

    public void PlayJumpSFX()
    {
        sfxSource.clip = jumpSFX;
        sfxSource.Play();
    }
    public void PlayDeathSFX()
    {
        sfxSource.clip = deathSFX;
        sfxSource.Play();
    }
    public void PlayBgMusic()
    {
        musicSource.clip = backgroundMusic;
        musicSource.Play();
    }
}
