using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f;
    public float jumpForce = 12.0f;
    public float dashSpeed = 15.0f; // Speed during the dash
    public float dashDuration = 0.2f; // How long the dash lasts
    public float dashCooldown = 1.0f; // Time between dashes
    public BoxCollider2D groundCollider;

    private Rigidbody2D rb;
    private const float gravity = 2.0f;

    private int maxJumps = 1; // Allows one normal jump and one double jump
    private int jumpCount;

    private bool isDashing = false; // Is the player currently dashing?
    private bool canDash = true; // Is the player allowed to dash?

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = gravity;
        jumpCount = maxJumps;
    }

    void Update()
    {
        if (isDashing) return; // Disable normal movement during dash

        // Movement using velocity
        float moveInput = 0f;
        if (Input.GetKey(KeyCode.A)) moveInput = -1f;
        if (Input.GetKey(KeyCode.D)) moveInput = 1f;

        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        // Jumping logic
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpCount--; // Reduce jump count on each jump
        }

        // Reset jump count when touching the ground
        if (IsGrounded())
        {
            jumpCount = maxJumps;
        }

        // Dash input
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash(moveInput));
        }
    }

    private bool IsGrounded()
    {
        return groundCollider.IsTouchingLayers(LayerMask.GetMask("Ground"));
    }

    private IEnumerator Dash(float direction)
    {
        isDashing = true;
        canDash = false;

        float originalGravity = rb.gravityScale; // Save the original gravity
        rb.gravityScale = 0; // Disable gravity during dash

        // Apply dash velocity
        rb.velocity = new Vector2(direction * dashSpeed, 0);

        yield return new WaitForSeconds(dashDuration); // Wait for dash to end

        rb.gravityScale = originalGravity; // Restore gravity
        isDashing = false;

        // Start cooldown
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }
}



