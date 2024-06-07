using UnityEngine;

public class Phone_Shake : MonoBehaviour
{
    // The minimum change in position for a shake to be registered
    private float shakeDetectionThreshold = 1.5f;

    // The camera's position from the last frame
    private Vector3 lastPosition;

    bool shake = false;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize lastPosition with the current camera position
        lastPosition = Camera.main.transform.position;

        // Ensure this object has a Rigidbody2D component and is initially not affected by gravity
        Rigidbody rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the position difference between this frame and the last frame
        Vector3 position = Camera.main.transform.position;
        Vector3 deltaPosition = position - lastPosition;

        // If the position difference is greater than the threshold, a shake has occurred
        if (deltaPosition.magnitude >= shakeDetectionThreshold)
        {
            if(shake == false)
            {
                shake = true;
                Debug.Log("Shake detected!");
                UnityEngine.SceneManagement.SceneManager.LoadScene("PuzzleGameScene");
            }
        }

        // Update lastPosition with the current camera position for the next frame
        lastPosition = position;
    }
}