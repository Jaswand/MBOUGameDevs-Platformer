using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPos : MonoBehaviour
{
    private GameMaster gm;

    void Start(){
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        //transform.position = gm.lastCheckpointPos;
    }

    void update(){
        if(Input.GetKeyDown(KeyCode.Space)){
           SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
