using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private enum MovementState { idle, running, jumping, falling }


    private Animator ani;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private BoxCollider2D bc;
    private bool canDoubleJump;

    private float directionX = 0f;
    public float moveSpeed = 7f;
    public float jumpForce = 14f;

    public LayerMask jumpableGround;

    [SerializeField] private AudioSource jumpSoundEffect;
    [SerializeField] private AudioSource doubleJumpSoundEffect;

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
        if(IsGrounded()) {
            canDoubleJump = true;
        }

        directionX = Input.GetAxisRaw("Horizontal"); 
        rb.velocity = new Vector2(directionX * moveSpeed, rb.velocity.y);

        
        if (Input.GetButtonDown("Jump"))
        {
            if (IsGrounded()) 
            {
                jumpSoundEffect.Play();
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                
            } else {
                if (canDoubleJump) {
                    doubleJumpSoundEffect.Play();
                    rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                   canDoubleJump = false;
                }
            }
        }
        UpdateAnimation();
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

        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        ani.SetInteger("state", (int)state);
    }



    private bool IsGrounded()
    {
        return Physics2D.BoxCast(bc.bounds.center, bc.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
