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
    private bool canInteract = false;
    private bool isInteracting = false;

    public bool InteractInput { get => isInteracting; set => isInteracting = value; }
    public bool CanInteract { get => canInteract; set => canInteract = value; }

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

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.started) isInteracting = true;
        else if (context.canceled) isInteracting = false;
    }

    private void FixedUpdate()
    {
        playerMovement.Move(moveInput);
        playerAnimation.SetMovementAnimation(moveInput, isMoving);
    }
}
