using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderPause : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Level 1"); // Loads de eerstvolgende scene na deze (Check build Settings index)
    }
}
