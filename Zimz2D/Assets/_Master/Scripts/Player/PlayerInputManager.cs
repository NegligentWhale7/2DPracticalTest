using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputManager : MonoBehaviour
{
    private PlayerLocomotionBase playerMovement;
    private PlayerAnimationsManager playerAnimation;
    private float moveInput;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerLocomotionBase>();
        playerAnimation = GetComponent<PlayerAnimationsManager>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>().x;
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            playerMovement.Jump();
        }
    }

    private void FixedUpdate()
    {
        playerMovement.Move(moveInput);
        playerAnimation.SetMovementAnimation(moveInput);
        playerAnimation.SetJumpAnimation(playerMovement.IsGrounded());
    }
}
