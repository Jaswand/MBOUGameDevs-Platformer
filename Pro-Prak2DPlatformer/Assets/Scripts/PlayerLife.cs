using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    public static PlayerLife Instance { get; set; }
    [SerializeField] public int health = 100;
    private int MAX_HEALTH = 100;
    private Rigidbody2D rb;
    private Animator ani;
    private Vector3 respawnPoint;
    private GameObject fallDetector;
    private Collider2D _collider;

    [SerializeField] private AudioSource deathSoundEffect;
    [SerializeField] private AudioSource deathSoundEffect2;
    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        respawnPoint = transform.position;

         if ( Instance != null && Instance != this )
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Death"))
        {
            Damage(50);
        } 
        if (collision.gameObject.CompareTag("Border"))
        {
            Damage(100);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "FallDetector")
        {
            transform.position = respawnPoint;
        }
        else if (collision.tag == "Checkpoint")
        {
            Debug.Log("checkpoint hit");
            respawnPoint = transform.position;
        }
    }

    public void Damage(int amount)
    {
        if(amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative Damage");
        }

        this.health -= amount;

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
        deathSoundEffect.Play();
        deathSoundEffect2.Play();
        rb.bodyType = RigidbodyType2D.Static;
        ani.SetTrigger("death");
    }

     private void Destroy()
    {
        Destroy(gameObject);
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    

 
}
