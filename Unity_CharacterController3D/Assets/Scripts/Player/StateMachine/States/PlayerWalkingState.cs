using UnityEngine;

public class PlayerWalkingState : PlayerBaseState
{
    public PlayerWalkingState(PlayerStateMachine stateMachine, CharacterController characterController, InputHandler inputHandler)
    : base(stateMachine, characterController, inputHandler) { }

    private readonly float movementSpeed = 7f;

    public override void EnterState()
    {
        //start walking animation
    }

    public override void ExitState()
    {
        //stop walking animation
    }

    public override void OnControllerColliderHit()
    {
       
    }

    public override void UpdateState()
    {
        if (inputHandler.IsJumpBttnPressed() || !characterController.isGrounded)
        {
            playerStateMachine.SwitchState(playerStateMachine.jumpingState);
        }

        Vector2 rawInput = inputHandler.GetInputVector();

        if (rawInput == Vector2.zero)
        {
            playerStateMachine.SwitchState(playerStateMachine.idlingState);
        }

        Vector3 velocity = playerStateMachine.playerCameraTransform.right * rawInput.x 
            + playerStateMachine.playerCameraTransform.forward * rawInput.y;
        
        if(velocity.sqrMagnitude > 1)
        {
            velocity.Normalize();
        }

        characterController.Move(velocity * movementSpeed * Time.deltaTime);
    }
}
