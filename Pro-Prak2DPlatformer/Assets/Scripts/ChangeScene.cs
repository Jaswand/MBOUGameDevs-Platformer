using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    //Hier laden we de sceneID  van de scene waar we naartoe willen gaan   
    public void MoveToScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }

    // Deze scene wordt geroept wanneer de player op de quit button klikt
    public void Quit()
    {
        Application.Quit();
    }
}
