using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator ani;

    [SerializeField] private AudioSource deathSoundEffect;
    [SerializeField] private AudioSource deathSoundEffect2;


    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Death"))
        {
            Die();
        }
    }
    
    private void Die()
    {
        deathSoundEffect.Play();
        deathSoundEffect2.Play();
        rb.bodyType = RigidbodyType2D.Static;
        ani.SetTrigger("death");
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
