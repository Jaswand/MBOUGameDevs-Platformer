using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuLoader : MonoBehaviour
{
    public GameObject PauseMenu;

    public static bool isPaused;


    void Start()
    {
        PauseMenu.SetActive(false);
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Debug.Log("Resuming Game.");
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                Resume();
            }
            else
            {
                Debug.Log("Pausing Game.");
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                Pause();

            }
        }
    }

    public void Resume()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void Pause()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

}
