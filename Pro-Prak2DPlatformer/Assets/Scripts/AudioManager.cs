using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{ 
    public static AudioManager Instance { get; private set; }

    public AudioSource AudioSource;

    public float example;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }

        else
        {
            Instance = this;
        }
    }
    public void PlaySound(AudioClip clip)
    {
        AudioSource.PlayOneShot(clip);
    }

    public void PlayAmbience(AudioClip clip)
    {
        AudioSource.clip = clip;
        AudioSource.Play();
        AudioSource.loop = true;
    }
}
