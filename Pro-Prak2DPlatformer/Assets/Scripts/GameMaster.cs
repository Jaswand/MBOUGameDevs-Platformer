using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public static GameMaster instance;
    public List<Transform> checkpoints;

    private Transform lastCheckpoint;

    void Awake(){

        if(instance == null){
            instance = this;
            DontDestroyOnLoad(instance);
        } else {
            Destroy(gameObject);
        }
        
        ResetCheckpoint();

    }

    public void SetLastCheckpoint(Transform checkpoint)
    {
        lastCheckpoint = checkpoint;
    }

    public void ResetCheckpoint()
    {
        lastCheckpoint = checkpoints[0];
    }



}
