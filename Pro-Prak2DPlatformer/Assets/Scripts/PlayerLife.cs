using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
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
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Death"))
        {
            deathSoundEffect.Play();
            deathSoundEffect2.Play();
            Die();
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
    
    private void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        ani.SetTrigger("death");
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    

 
}
