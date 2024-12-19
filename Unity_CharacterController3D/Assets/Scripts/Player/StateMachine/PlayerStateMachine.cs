using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(InputHandler))]
public class PlayerStateMachine : MonoBehaviour
{
    [Header("Camera Transform")]
    public Transform playerCameraTransform;

    private CharacterController characterController;
    private InputHandler inputHandler;

    private PlayerBaseState currentState;

    public PlayerIdlingState idlingState;
    public PlayerWalkingState walkingState;
    public PlayerJumpingState jumpingState;

    private void OnEnable()
    {
        characterController = GetComponent<CharacterController>();
        inputHandler = GetComponent<InputHandler>();

        idlingState = new PlayerIdlingState(this, characterController, inputHandler);
        walkingState = new PlayerWalkingState(this, characterController, inputHandler);
        jumpingState = new PlayerJumpingState(this, characterController, inputHandler);
    }

    public void UpdateState()
    {
        currentState?.UpdateState();
    }

    public void SwitchState(PlayerBaseState newState)
    {
        currentState?.ExitState();
        currentState = newState;
        currentState.EnterState();
    }

    public void OnControllerColliderHit()
    {
        currentState?.OnControllerColliderHit();
    }
}
