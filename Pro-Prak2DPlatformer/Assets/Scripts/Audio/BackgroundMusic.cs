using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    private static BackgroundMusic backgroundMusic;
    AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void Awake()
    {
        if (backgroundMusic == null)
        {
            backgroundMusic = this;
            DontDestroyOnLoad(backgroundMusic);
        }

        else
        {
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
            audioSource.mute = !audioSource.mute;
    }
}
