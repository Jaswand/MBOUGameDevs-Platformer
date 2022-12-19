using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDestroy : MonoBehaviour
{
    public float timeLeft = 1.0f;
    private int damage = 50;

    public GameObject destroyPEeffect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0.5)
        {
            Debug.Log("Time's up!!!!");
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;

        if (collisionGameObject.name != "Player")
        {
            DestroyPE();
        }

        void DestroyPE()
        {
            if (destroyPEeffect != null)
            {
                Instantiate(destroyPEeffect, transform.position, Quaternion.identity);
            }

            Destroy(gameObject);
        }

        if (collisionGameObject.layer == 8)
        {
            Health health = collisionGameObject.GetComponent<Health>();
            health.Damage(damage);

        }
        else if (collisionGameObject.layer == 9)
        {
            BossHealth health = collisionGameObject.GetComponent<BossHealth>();
            health.TakeDamage(damage);
        }

    }

}
