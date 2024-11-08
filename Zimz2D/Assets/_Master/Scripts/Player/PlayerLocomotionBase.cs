using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLocomotionBase : MonoBehaviour
{
    [Header("Movement Settings")]
    public float speed = 5f;
    public float jumpForce = 10f;
    public LayerMask groundLayer;
    public Transform groundCheck;

    private Rigidbody2D rb;
    private bool isFacingRight = false;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Move(float moveInput)
    {
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if(!isFacingRight && moveInput > 0)
        {
            Flip();
        }
        else if (isFacingRight && moveInput < 0)
        {
            Flip();
        }
    }

    public void Jump()
    {
        if (IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    public void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
}
