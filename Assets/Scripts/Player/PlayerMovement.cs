using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    /// <summary>
    /// This script allows the player to move their character.
    /// </summary>
    public Animator anim;
    private Rigidbody2D rb;

    public float runSpeed = 40f;
    float horizontalMove = 0f;
    float jumpForce = 400f; // Amount of force added when the player jumps.
    float movementSmoothing = .05f;  // How much to smooth out the movement

    bool jump = false;
    bool facingRight = true;  // For determining which way the player is currently facing.
    private bool isPlayerOnGround; // Whether or not the player is grounded.

    [SerializeField]
    private Transform groundCheck; // A position marking where to check if the player is grounded.
    [SerializeField]
    private Transform ceilingCheck; // A position marking where to check for ceilings
    [SerializeField]
    private bool airControl = false; // Whether or not a player can steer while jumping;
    [SerializeField]
    private LayerMask whatIsGround; // A mask determining what is ground to the character

    private Vector3 playerVelocity = Vector3.zero;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        anim.SetFloat("Speed", Mathf.Abs(horizontalMove)); //make movement always positive
        Move(horizontalMove * Time.fixedDeltaTime, jump); // Move our character
        jump = false;

        if (Input.GetButtonDown("Jump")) // If player press spacebar
        {
            jump = true;
            anim.SetBool("isJumping", true); // Jump
        }
        else
        {
            jump = false;
            anim.SetBool("isJumping", false);
        }
    }

    void FixedUpdate()
    {
        isPlayerOnGround = false;

        RaycastHit2D check = Physics2D.Raycast(groundCheck.position, -groundCheck.transform.up, 0.3f, whatIsGround); //If player collides with ground, 

        if (check.collider != null)
        {
            isPlayerOnGround = true; // Player is on ground
        }
    }

    void Move(float move, bool jump)
    { 
        if (isPlayerOnGround || airControl) //only control the player if grounded or airControl is turned on
        {
            Vector3 targetVelocity = new Vector2(move * 10f, rb.velocity.y); // Move the character by finding the target velocity
            rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref playerVelocity, movementSmoothing); // And then smoothing it out and applying it to the character
            
            if (move > 0 && !facingRight) // If the input is moving the player right and the player is facing left...
            {
                Flip(); // ... flip the player.
            }
            else if (move < 0 && facingRight) // Otherwise if the input is moving the player left and the player is facing right...
            {
                Flip(); // ... flip the player.
            }
        }

        if (isPlayerOnGround && jump) // If the player should jump...
        {
            isPlayerOnGround = false;
            rb.AddForce(new Vector2(0f, jumpForce)); // Add a vertical force to the player.
        }
    }

    void Flip()
    {
        facingRight = !facingRight;// Switch the way the player is labelled as facing.

        Vector3 theScale = transform.localScale; 
        theScale.x *= -1; // Multiply the player's x local scale by -1.
        transform.localScale = theScale;
    }

    void OnCollisionEnter2D(Collision2D collision) // When player jumps onto moving platform
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            this.transform.parent = collision.transform; // Player becomes child of moving platform
        }
    }

    void OnCollisionExit2D(Collision2D collision) // When player jumps off moving platform
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            this.transform.parent = null; // Moving platform is no longer a parent of player
        }
    }
}
