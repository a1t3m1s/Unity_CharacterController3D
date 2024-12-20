using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerStateMachine : MonoBehaviour
{
    [Header("Serialized Fields")]
    public Transform playerCameraTransform;
    [field: SerializeField]
    private InputHandler inputHandler;

    private CharacterController characterController;

    private PlayerBaseState currentState;

    public PlayerIdlingState idlingState;
    public PlayerWalkingState walkingState;
    public PlayerJumpingState jumpingState;

    private void OnEnable()
    {
        characterController = GetComponent<CharacterController>();

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
