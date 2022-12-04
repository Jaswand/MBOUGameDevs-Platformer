using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChestOpener : MonoBehaviour
{
    public GameObject Chest;
    private Animator ani;
    public GameObject ChestText;

    void Start()
    {
        ani = GetComponent<Animator>();
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
            ChestText.SetActive(true);
        } else if (ani.GetBool("open") == false)
        {
            ChestText.SetActive(false);
        }
    }
}
