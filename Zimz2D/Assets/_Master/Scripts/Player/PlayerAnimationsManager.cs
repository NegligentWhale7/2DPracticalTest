using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationsManager : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer mainSpriteRenderer;
    [SerializeField] private GameObject weapon;

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

    public void SetAttackAnimation()
    {
        //mainSpriteRenderer.enabled = false;
        weapon.SetActive(true);
        animator.SetBool("isAttacking", true);
    }

    public void DisableAttackAnimation()
    {
        //mainSpriteRenderer.enabled = true;
        weapon.SetActive(false);
        animator.SetBool("isAttacking", false);
    }
}
