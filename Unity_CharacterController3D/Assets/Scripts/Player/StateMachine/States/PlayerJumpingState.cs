using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerJumpingState : PlayerBaseState
{
    public PlayerJumpingState(PlayerStateMachine stateMachine, CharacterController characterController, InputHandler inputHandler)
    : base(stateMachine, characterController, inputHandler) { }

    private readonly float jumpHeight = 2f;
    private readonly float gravity = -9.81f;
    
    private Vector3 velocity;

    public override void EnterState()
    {
        //start jumping or falling animation

        movementSpeed = 5f;
        velocity = Vector3.zero;
    }

    public override void ExitState()
    {
        //stop jumping animation
    }

    public override void OnControllerColliderHit()
    {
        playerStateMachine.SwitchState(playerStateMachine.idlingState);
    }

    public override void UpdateState()
    {
        bool isGrounded = characterController.isGrounded;

        Vector3 rawInput = playerStateMachine.playerCameraTransform.right * inputHandler.GetInputVector().x 
            + playerStateMachine.playerCameraTransform.forward * inputHandler.GetInputVector().y;

        if (rawInput.sqrMagnitude > 1)
        {
            rawInput.Normalize();
        }

        velocity.x = rawInput.x * movementSpeed;
        velocity.y += gravity * Time.deltaTime;
        velocity.z = rawInput.z * movementSpeed;

        if (isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

        characterController.Move(velocity * Time.deltaTime);
    }
}
