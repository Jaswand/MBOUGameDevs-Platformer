using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerups : MonoBehaviour
{
    public PowerupEffects powerupEffects;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
        powerupEffects.Apply(collision.gameObject);
    }
}
