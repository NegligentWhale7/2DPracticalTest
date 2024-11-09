using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationsManager : MonoBehaviour
{
    [SerializeField] private Animator animator;
    public Animator Animator { get => animator; set { animator = value; } }

    private void Awake()
    {
        //animator = GetComponent<Animator>();
    }

    public void SetMovementAnimation(Vector2 moveInput, bool isMoving)
    {
        animator.SetFloat("Horizontal", moveInput.x);
        animator.SetFloat("Vertical", moveInput.y);
        animator.SetBool("isMoving", isMoving);
        // animator.SetFloat("Speed", Mathf.Abs(moveInput));
    }

    public void SetJumpAnimation(bool isGrounded)
    {
       // animator.SetBool("IsGrounded", isGrounded);
    }
}
