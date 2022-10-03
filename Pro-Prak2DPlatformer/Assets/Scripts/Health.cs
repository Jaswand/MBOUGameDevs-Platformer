using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int health = 100;
    private Animator ani;

    private int MAX_HEALTH = 100;

    void Start()
    {
        ani = GetComponent<Animator>();
    }

    public void Damage(int amount)
    {
        if(amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative Damage");
        }

        this.health -= amount;

        if(health == 50)
        {
            ani.SetTrigger("hit");
        }

        if(health <= 0)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative Healing");
        }

        bool wouldBeOverMaxHealth = health + amount > MAX_HEALTH;

        if (wouldBeOverMaxHealth)
        {
            this.health = MAX_HEALTH;
        }
        else 
        {
            this.health += amount;
        }
        
    }
    
     private void Die()
     {
        ani.SetTrigger("death");
     }

    private void Destroy()
    {
        Destroy(gameObject);
    }
}
