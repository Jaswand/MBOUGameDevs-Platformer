using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : MonoBehaviour
{

    public static event Action<BossEnemy> OnEnemyKilled;
    [SerializeField] float health, maxHealth = 3f;

    [SerializeField] float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Transform target;
    public Vector2 moveDirection;

    void Awake() 
    {
        rb = GetComponent<Rigidbody2D>();
        
    }
    
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        target = GameObject.Find("Player").transform;
      
    }

    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rb.rotation = angle;
            moveDirection = direction;
        }
    }

    private void FixedUpdate()
    {
        if(target)
        {
             rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * moveSpeed;
        }
       
    }

    public void TakeDamage(float damageAmount) {
        Debug.Log($"Damage Amount: {damageAmount}");
        health -= damageAmount;
        Debug.Log($"Health is now: {health}");

        if (health <= 0) {
           Destroy(gameObject);
           BossEnemy.OnEnemyKilled?.Invoke(this);
        }
    }
    
}
