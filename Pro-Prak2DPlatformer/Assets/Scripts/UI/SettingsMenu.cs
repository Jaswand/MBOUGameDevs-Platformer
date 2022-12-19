using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;
using System.ComponentModel;
using TMPro.Examples;
using Unity.VisualScripting;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer mainMixer;

    public void SetFullScreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
    public void SetVolume(float volume)
    {
        mainMixer.SetFloat("Volume", volume);
    }


}
