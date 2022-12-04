using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI MyScore;
    [SerializeField] private int ScoreNum;

    [SerializeField] private AudioSource coinSoundEffect;
    // Start is called before the first frame update
    void Start()
    {
        ScoreNum = 0;
        MyScore.text = "Score: " + ScoreNum;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            coinSoundEffect.Play();
            ScoreNum += 1;
            MyScore.text = "Score: " + ScoreNum;
            Destroy(collision.gameObject);

        }
    }
}