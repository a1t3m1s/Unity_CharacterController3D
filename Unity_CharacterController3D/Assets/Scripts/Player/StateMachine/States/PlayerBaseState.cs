using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBaseState
{
    protected PlayerStateMachine playerStateMachine;
    protected CharacterController characterController;
    protected InputHandler inputHandler;
     
    protected float movementSpeed;

    protected Vector3 inputMovement;
    
    public PlayerBaseState(PlayerStateMachine playerStateMachine, CharacterController characterController, InputHandler inputActions)
    {
        this.playerStateMachine = playerStateMachine;
        this.characterController = characterController;
        this.inputHandler = inputActions;
    }

    public abstract void EnterState();
    public abstract void UpdateState();
    public abstract void ExitState();
    public abstract void OnControllerColliderHit();
}