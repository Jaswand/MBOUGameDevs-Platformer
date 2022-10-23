using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour
{

    private int amount;
    public Slider slider;
    public TMP_Text text;
    private void Start()
    {
       
    }

    // Update is called once per frame
    private void Update()
    {
        slider.value=PlayerLife.Instance.health;
        text.text="health :" +PlayerLife.Instance.health;
        
    }
}
