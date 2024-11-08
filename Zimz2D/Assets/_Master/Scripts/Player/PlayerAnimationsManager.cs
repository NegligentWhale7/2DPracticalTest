using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationsManager : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void SetMovementAnimation(float moveInput)
    {
        animator.SetFloat("Speed", Mathf.Abs(moveInput));
    }

    public void SetJumpAnimation(bool isGrounded)
    {
        animator.SetBool("IsGrounded", isGrounded);
    }
}
