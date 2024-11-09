using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputManager : MonoBehaviour
{
    private PlayerLocomotionBase playerMovement;
    private PlayerAnimationsManager playerAnimation;
    private Vector2 moveInput;
    private bool isMoving = false;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerLocomotionBase>();
        playerAnimation = GetComponent<PlayerAnimationsManager>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        if (moveInput != Vector2.zero) isMoving = true;
        else isMoving = false;
    }

    private void FixedUpdate()
    {
        playerMovement.Move(moveInput);
        playerAnimation.SetMovementAnimation(moveInput, isMoving);
    }
}
