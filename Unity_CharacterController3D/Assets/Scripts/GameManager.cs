using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameManager Instance { get; private set; }

    public void OnEnable()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }

        Cursor.lockState = CursorLockMode.Locked;
    }

    private void OnDestroy()
    {
        Instance = null;
    }
}
