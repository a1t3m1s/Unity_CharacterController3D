using UnityEngine;

public class PlayerIdlingState : PlayerBaseState
{
    public PlayerIdlingState(PlayerStateMachine playerStateMachine, CharacterController characterController, InputHandler inputHandler) 
        : base(playerStateMachine, characterController, inputHandler) { }

    public override void EnterState()
    {
        //start idle animation
    }

    public override void ExitState()
    {
        //stop idle animation
    }

    public override void OnControllerColliderHit()
    {
       
    }

    public override void UpdateState()
    {
        if (inputHandler.GetInputVector() != Vector2.zero)
        {
            playerStateMachine.SwitchState(playerStateMachine.walkingState);
        }

        if(inputHandler.IsJumpBttnPressed())
        {
            playerStateMachine.SwitchState(playerStateMachine.jumpingState);
        }
    }
}
