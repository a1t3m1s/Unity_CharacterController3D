using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

[RequireComponent(typeof(PlayerStateMachine))]

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance { get; private set; }

    private PlayerStateMachine playerStateMachine;

    private void Awake()
    {
        playerStateMachine = GetComponent<PlayerStateMachine>();
    }

    private void OnEnable()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }

    private void Start()
    {
        playerStateMachine.SwitchState(playerStateMachine.idlingState);
    }

    private void Update()
    {
        playerStateMachine.UpdateState();
    }

    private void OnControllerColliderHit()
    {
        playerStateMachine.OnControllerColliderHit();
    }

}
