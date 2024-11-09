using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLocomotionBase : MonoBehaviour
{
    [Header("Movement Settings")]
    public float speed = 5f;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Move(Vector2 moveInput)
    {
        // Ajuste la velocidad de movimiento en ambos ejes X y Y
        rb.velocity = moveInput * speed;
    }
}
