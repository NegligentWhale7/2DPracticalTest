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

    private void Update()
    {
        // Capturar la entrada de movimiento del usuario
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Pasar la entrada de movimiento al método de movimiento
        Move(new Vector2(horizontal, vertical));
    }
}
