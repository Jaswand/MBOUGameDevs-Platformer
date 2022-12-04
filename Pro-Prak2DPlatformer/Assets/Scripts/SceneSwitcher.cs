using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            SceneManager.LoadScene("StartScreen");
        }
    }
    // plus 1 Scene
    public void playGame()
    {
        SceneManager.LoadScene("StartScreen");
    }
    // minus 1 Scene
    public void Back()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

   
    
}