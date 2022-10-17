using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerups : MonoBehaviour
{
    public GameObject pickupEffect;
    public float multiplier = 2.5f;


    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;

            StartCoroutine( Pickup(other) ); 
        }
    }

    IEnumerator Pickup(Collider2D player)
    {
        Instantiate(pickupEffect, transform.position, transform.rotation);

        PlayerMovement stats = player.GetComponent<PlayerMovement>();

        stats.moveSpeed += 3.5f;

        yield return new WaitForSeconds(6.0f);


        stats.moveSpeed -= 3.5f;

        Destroy(gameObject);
    }
      
}   