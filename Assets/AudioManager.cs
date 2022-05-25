using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip song;
    public AudioClip end;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.clip = end;
            audioSource.Play();
            audioSource.loop = true;
        }
    }

    public void RestartMusic()
    {
        audioSource.clip = song;
        audioSource.Play();
        audioSource.loop = false;
    }
}
