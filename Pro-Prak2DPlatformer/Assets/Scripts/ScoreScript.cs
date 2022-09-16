using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI MyScore;
    [SerializeField] private int ScoreNum;

    // Start is called before the first frame update
    void Start()
    {
        ScoreNum = 0;
        MyScore.text = "Score:" + ScoreNum;
    }

    void OnCollisionEnter(UnityEngine.Collision collisionInfo)
    {

        if (collisionInfo.gameObject.tag == "Coin")
        {
            ScoreNum += 1;
            MyScore.text = "Score" + ScoreNum;
            Destroy(collisionInfo.gameObject);

        }

    }
}