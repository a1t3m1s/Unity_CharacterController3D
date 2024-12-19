using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private InputActions inputActions;

    private void OnEnable()
    {
        if(inputActions == null)
        {
            inputActions = new InputActions();
        }
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    public bool IsJumpBttnPressed()
    {
        return inputActions.Player.Jump.ReadValue<float>() > 0f;
    }

    public Vector2 GetInputVector()
    {
        return inputActions.Player.Movement.ReadValue<Vector2>();
    }
}
