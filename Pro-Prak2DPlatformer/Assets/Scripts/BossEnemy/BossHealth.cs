using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossHealth : MonoBehaviour
{
	public static BossHealth Instance { get; set; }

	public int health = 500;

	public GameObject deathEffect;

	private Animator ani;

	public bool isInvulnerable = false;

	public void TakeDamage(int damage)
	{
		if (isInvulnerable)
			return;

		health -= damage;

		if (health <= 250)
		{
			GetComponent<Animator>().SetBool("IsEnraged", true);
		}

		if (health <= 0)
		{
			Die();
		}
	}

    private void Start()
    {
		if (Instance != null && Instance != this)
		{
			Destroy(this);
		}
		else
		{
			Instance = this;
		}

		ani = GetComponent<Animator>();
	}

	private void Destroy()
	{
		Destroy(gameObject);
	}

	void Die()
	{
		ani.SetTrigger("Death");
	}

	private void NextScene()
	{
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}