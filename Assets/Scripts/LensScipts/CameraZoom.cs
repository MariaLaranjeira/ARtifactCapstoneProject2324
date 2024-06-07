using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public Camera arCamera;
    public float zoomFOV = 30f; // Field of view for zoomed-in effect
    public float normalFOV = 60f; // Field of view for normal effect
    public float zoomSpeed = 5f; // Speed of zoom transition

    private bool isZoomedIn = true;

    void Start()
    {
        // Set initial zoom level
        arCamera.fieldOfView = zoomFOV;
    }

    void Update()
    {
        // For Testing
        if (Input.GetKeyDown(KeyCode.Z))
        {
            isZoomedIn = !isZoomedIn;
        }

        // Zoom VS unZoom
        if (isZoomedIn)
        {
            arCamera.fieldOfView = Mathf.Lerp(arCamera.fieldOfView, zoomFOV, Time.deltaTime * zoomSpeed);
        }
        else
        {
            arCamera.fieldOfView = Mathf.Lerp(arCamera.fieldOfView, normalFOV, Time.deltaTime * zoomSpeed);
        }
    }
}

