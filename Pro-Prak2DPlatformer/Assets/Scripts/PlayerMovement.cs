using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{

    private enum MovementState { idle, running, jumping, falling }

    private Animator ani;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private BoxCollider2D bc;
    private bool canDoubleJump;


    private bool grounded;

    public float maxSpeed = 20f;

    private float directionX = 0f;
    public float moveSpeed = 7f;
    public float jumpForce = 14f;

    public LayerMask jumpableGround;

    [SerializeField] private AudioSource jumpSoundEffect;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        bc = GetComponent<BoxCollider2D>();

    }

    // Update is called once per frame
    private void Update()
    {
        if (IsGrounded())
        {
            canDoubleJump = true;
        }

        directionX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(directionX * moveSpeed, rb.velocity.y);
        ani.SetFloat("run", Mathf.Abs(directionX));

        if (Input.GetButtonDown("Jump"))
        {
            jumpSoundEffect.Play();
            Jump();
        }
        ani.SetBool("grounded", grounded);

        UpdateAnimation();

        if (rb.velocity.x > maxSpeed)
        {
            rb.velocity = new Vector2(maxSpeed, rb.velocity.y);
        }
    }
    private void Jump()
    {
        grounded = false;
        ani.SetBool("jump", true);

        if (IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);

        }
        else
        {
            if (canDoubleJump)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                canDoubleJump = false;
            }
        }
    }
    // Zorgt dat grounded true wordt als het "ground" tags aanraakt
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }

        if (collision.gameObject.tag == "Death")
        {
            grounded = true;
        }

    }

    private void UpdateAnimation()
    {
        MovementState state;
        

        if (directionX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (directionX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else 
        {
            state = MovementState.idle;
        }


        ani.SetInteger("state", (int)state);
    }



    private bool IsGrounded()
    {
        return Physics2D.BoxCast(bc.bounds.center, bc.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
