using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    private int damage = 50;
    private float directionX = 0f;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.GetComponent<Health>() != null)
        {
            Health health = collider.GetComponent<Health>();
            health.Damage(damage);
        }

        if (collider.GetComponent<BossHealth>() != null)
        {
            BossHealth health = collider.GetComponent<BossHealth>();
            health.TakeDamage(damage);
        }
    }
}
