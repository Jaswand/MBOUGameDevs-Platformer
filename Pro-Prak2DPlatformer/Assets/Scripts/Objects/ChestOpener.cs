using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ChestOpener : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI MyScore;
    [SerializeField] private int SecretNum;
    public GameObject Chest;
    private Animator ani;
    public GameObject ChestText;

    void Start()
    {
        ani = GetComponent<Animator>();
        MyScore.text = "Secrets: "+SecretNum+"/1";
        ChestText.SetActive(false);
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ani.SetBool("open", true);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        ani.SetBool("open", false);
    }

    void Update()
    {
        if(ani.GetBool("open") == true && Input.GetKeyDown(KeyCode.F))
        {
            Destroy(gameObject);
            SecretNum += 1;
            MyScore.text = "Secrets: " + SecretNum + "/1";
        }
        else if (ani.GetBool("open") == true)
        {
            ChestText.SetActive(true);
        }
    }
}
