using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private enum States 
    {
        StartScreen,
        Kantoor_0,
        Bureau_0,
        Ladenkast_0,
        Slot_0,
        Kantoor_1,
        Ladenkast_1,
        Slot_1
    };

    private States currentState;

    public Text textField;

    void Start()
    {
        currentState = States.StartScreen;    
    }
    
    void Update()
    {
        if(currentState == States.StartScreen)
        {
            StartScreen();
        }
        if(currentState == States.Kantoor_0)
        {
            Kantoor0();
        }       
    }

    private void StartScreen()
    {
        textField.text = "Welkom bij onze game! Druk op S om te starten";
        if(Input.GetKeyDown(KeyCode.S))
        {
            currentState = States.Kantoor_0;
        } 
    }

    private void Kantoor0()
    {
        textField.text = "Je bevind je in een oud verlaten kantoor voor je staat een bureau en rechts van je een ladenkast. Wanneer je achterom kijkt is er een gesloten deur! \n Druk op B voor het bureau, L voor de ladenkast en D voor de deur.";
        if(Input.GetKeyDown(KeyCode.B))
        {
            currentState = States.Bureau_0;
        }
        if(Input.GetKeyDown(KeyCode.L))
        {
            currentState = States.Ladenkast_0;
        }
        if(Input.GetKeyDown(KeyCode.D))
        {
            currentState = States.Slot_0;
        }
    }

    private void Bureau_0()
    {
        textField.text = "Welkom bij onze game! Druk op S om te starten";
    }
}
