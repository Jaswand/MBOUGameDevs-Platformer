using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelselector : MonoBehaviour { 

    // Start is called before the first frame update
    void Start() { 
    
        
    }

    public void OpenScene() { 
       SceneManager.LoadScene("Level1");
    }
}
