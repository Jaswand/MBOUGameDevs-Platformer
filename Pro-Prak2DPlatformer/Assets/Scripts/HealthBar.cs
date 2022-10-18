using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider healthBar;
    [SerializeField] private Image healthfill;  
    [SerializeField] private Gradient gradient;

    private float currentHealth;
    private float maxHealth;
    private bool infinitHealth;
    private bool isFullHealth;

    public Slider slider;
    public Image fill;

    private Health health;
    public int damage = 2;
    public Health playerHealth;


    private void Start()
    {
        health = gameObject.GetComponent<Health>();
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        healthBar = GetComponent<Slider>();
        slider = GetComponent<Slider>();

    }
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;

        fill.color = gradient.Evaluate(1f);
       
    }

    public void SetInitialHealth(float health)
    {
        healthBar.maxValue = health;
        healthBar.value = health;

        healthfill.color = gradient.Evaluate(1f);
    }

    public void SetHealth(int health, int hp)
    {
        slider.value = health;
        healthBar.value = hp;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    private void OnCollisonEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            health.Damage(1);
        }
    }

    private void update()
    {
        if (healthBar.value == 0)
        {
            Destroy(gameObject);
        }
    }  
}
