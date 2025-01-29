using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f;
    public float jumpForce = 12.0f;
    public BoxCollider2D groundCollider;

    private Rigidbody2D rb;
    private const float gravity = 2.0f;

    private int maxJumps = 2; // Allows one normal jump and one double jump
    private int jumpCount;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = gravity;
        jumpCount = maxJumps;
    }

    void Update()
    {
        // Movement using velocity instead of modifying transform directly
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
    }

    private bool IsGrounded()
    {
        return groundCollider.IsTouchingLayers(LayerMask.GetMask("Ground"));
    }
}


