using Cinemachine;
using UnityEngine;

[RequireComponent(typeof(CinemachineVirtualCamera))]
public class CameraZoom : MonoBehaviour
{
    [Header("Input Handler")]
    [field: SerializeField]
    private InputHandler inputHandler;

    [Header("Zoom Settings")]
    [field: SerializeField]
    private float minDistance = 1f;
    [field: SerializeField]
    private float maxDistance = 6f;
    [field: SerializeField]
    private float senfitivity = 1f;

    private CinemachineVirtualCamera virtualCamera;
    private CinemachineComponentBase componentBase;

    private float cameraDistance;

    private void Awake()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
    }

    private void Update()
    {
        if(componentBase == null)
        {
            componentBase = virtualCamera.GetCinemachineComponent(CinemachineCore.Stage.Body);
        }

        float scrollValue = Mathf.Clamp(inputHandler.GetMouseScroll(), -1, 1);

        if (scrollValue != 0)
        {
            cameraDistance = scrollValue * senfitivity;

            (componentBase as CinemachineFramingTransposer).m_CameraDistance = Mathf.Clamp((componentBase as CinemachineFramingTransposer).m_CameraDistance - cameraDistance,
                minDistance, maxDistance);
        }
    }
}
