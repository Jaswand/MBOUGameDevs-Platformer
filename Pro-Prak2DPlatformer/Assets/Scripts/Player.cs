 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
 
public class Player : MonoBehaviour
{
    [SerializeField] private Slider healthBar;
    [SerializeField] private Image healthfill;  
    [SerializeField] private Gradient gradient;

    private float currentHealth;
    private float maxHealth;
    private bool infinitHealth;
    private bool isFullHealth;

  public void SetInitialHealth(float health)
    {
        healthBar.maxValue = health;
        healthBar.value = health;

        healthfill.color = gradient.Evaluate(1f);
    }

    public void SetHealth()
    {
        currentHealth = maxHealth;
        SetInitialHealth(maxHealth);
    }

    public void UpdateHealth(float currentHealth)
    {
        healthBar.value = currentHealth;

        healthfill.color = gradient.Evaluate(healthBar.normalizedValue);
    }

    public void TakeDamage(float damage)
    {
        if (infinitHealth == false)
        {
            currentHealth -= damage;

            UpdateHealth(currentHealth);

            if(currentHealth <= 1)
            {
                //spawnManager.OnPlayerDeath();
                Destroy(gameObject);
                Debug.Log("You are dead");
            }

            if (currentHealth < 20)
            {
                Debug.Log("Your health is very low");
            }
        }
        else
           return;
    }

    public void AddHealth(float healthamount)
    {
        if (currentHealth < maxHealth && isFullHealth == false)
        {
            currentHealth += healthamount;
            UpdateHealth(currentHealth);
            Debug.Log("Added " +healthamount+ "Health Points");
        }
        else
        {
            Debug.Log("Health is full");
        }
    }

    private void Update()
    {
       if (Input.GetKeyDown(KeyCode.Space))
            StaminaBar.instance.UseStamina(15);

        
    }
}