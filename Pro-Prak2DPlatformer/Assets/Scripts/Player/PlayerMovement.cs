using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{

    private enum MovementState { idle, running, jumping, falling }

    private Animator ani;
    private Rigidbody2D rb;
    public SpriteRenderer sprite;
    private BoxCollider2D bc;
    private bool canDoubleJump;

    private bool canDash = true;
    private bool isDashing;
    private float dashPower = 25f;
    private float dashTime = 0.2f;
    private float dashCooldown = 5f;

    private bool grounded;

    public float maxSpeed = 25f;

    public float directionX = 0f;
    public float moveSpeed = 7f;
    public float jumpForce = 14f;

    public LayerMask jumpableGround;

    [SerializeField] private AudioSource jumpSoundEffect;
    [SerializeField] private AudioSource dashSoundEffect;
    [SerializeField] private TrailRenderer tr;

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
        if (isDashing == false)
        {
            rb.velocity = new Vector2(directionX * moveSpeed, rb.velocity.y);
            ani.SetFloat("run", Mathf.Abs(directionX));
        }

        if (Input.GetButtonDown("Jump"))
        {
            jumpSoundEffect.Play();
            Jump();
        }
        ani.SetBool("grounded", grounded);

        UpdateAnimation();

        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            dashSoundEffect.Play();
            StartCoroutine(Dash());
        }
    }
    private void FixedUpdate()
    {
        if (rb.velocity.x > maxSpeed)
        {
            rb.velocity = new Vector2(maxSpeed, rb.velocity.y);
        }
        
        if (isDashing)
        {
            return;
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
        

        if (directionX != 0f)
        {
            state = MovementState.running;
            transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x) * directionX, transform.localScale.y);
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

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        // How fast the player dashes
        rb.velocity = new Vector2(transform.localScale.x * dashPower, 0f);
        tr.emitting = true;
        yield return new WaitForSeconds(dashTime);
        tr.emitting = false;
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }
}
