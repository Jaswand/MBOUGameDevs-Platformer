using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySelector : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] private Button[] allAnimationButtons;
    [SerializeField] private Button[] enableAnimationButtons;

    [Header("Game Objects")]
    [SerializeField] private GameObject[] allEnemyGOs;
    [SerializeField] private GameObject enableEnemy;

    [Header("Text")]
    [SerializeField] private Text enemyName;

    public void Start()
    {
        enemyName.text = "";
    }
    public void ChangeEnemies()
    {
        _DisableAllEnemies();
        _DisableAllButtons();
        _EnableEnemy();
        _EnableButton();
        _Rename();
    }

    public void _Rename()
    {
        enemyName.text = enableEnemy.gameObject.name;
    }

    public void _EnableButton()
    {
        for (int i = 0; i < enableAnimationButtons.Length; i++)
        {
            enableAnimationButtons[i].interactable = true;
        }
    }
    public void _DisableAllButtons()
    {
        for (int i = 0; i < allAnimationButtons.Length; i++)
        {
            allAnimationButtons[i].interactable = false;
        }
    }

    public void _EnableEnemy()
    {
        enableEnemy.SetActive(true);
    }
    public void _DisableAllEnemies()
    {
        for (int i = 0; i < allEnemyGOs.Length; i++)
        {
            allEnemyGOs[i].gameObject.SetActive(false);
        }
    }
}
