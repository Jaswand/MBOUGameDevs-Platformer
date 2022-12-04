using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Control : MonoBehaviour
{

    public void ResetTheGame()
    {
        SceneManager.LoadScene("StartScreen");
        print("De button werkt hoor!");
    }
}
