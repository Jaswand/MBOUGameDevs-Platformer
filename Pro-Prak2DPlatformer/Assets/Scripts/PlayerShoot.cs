using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{

    public float shootSpeed, shootTimer;

    private bool isShooting;
    public Transform shootPosition;
    public GameObject projectile;



    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        isShooting = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && !isShooting)
        {
            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot()
    {
        int direction()
        {
            if(transform.localScale.x < 0f)
            {
                return -1;
            }
            else
            {
                return +1;
            }
        }
        
        isShooting = true;
        GameObject newProjectile = Instantiate(projectile, shootPosition.position, Quaternion.identity);
        newProjectile.GetComponent<Rigidbody2D>().velocity = new Vector2(shootSpeed * direction() * Time.fixedDeltaTime, 0f);
        newProjectile.transform.localScale = new Vector2(newProjectile.transform.localScale.x * direction(), newProjectile.transform.localScale.y);
        yield return new WaitForSeconds(shootTimer);
        isShooting = false;
    }
}
