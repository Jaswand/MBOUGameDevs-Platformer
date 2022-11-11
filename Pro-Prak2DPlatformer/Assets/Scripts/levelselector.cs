using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class levelselector : MonoBehaviour {

    public int level;
    // Start is called before the first frame update
    void Start() { 
    
        
    }

    public void OpenScene() { 
       SceneManager.LoadScene("level " + level.ToString());
    }
}
