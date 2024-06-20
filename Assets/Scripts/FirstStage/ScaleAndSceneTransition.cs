using UnityEngine;
using UnityEngine.SceneManagement;

public class ScalingAndSceneTransition : MonoBehaviour
{
    public GameObject targetObject;
    public Vector3 targetScale = new Vector3(2f, 2f, 2f);
    public float scalingDuration = 3f;
    public string nextSceneName;

    private Vector3 initialScale;
    private float scalingTimeElapsed = 0f;
    private bool isScaling = false;

    private void Start()
    {
        if (targetObject != null)
        {
            initialScale = targetObject.transform.localScale;
        }
        else
        {
            Debug.LogError("ScalingAndSceneTransition: Target object is not set.");
        }
    }

    private void Update()
    {
        if (isScaling)
        {
            scalingTimeElapsed += Time.deltaTime;
            float progress = scalingTimeElapsed / scalingDuration;

            // Lerp the scale of the object
            targetObject.transform.localScale = Vector3.Lerp(initialScale, targetScale, progress);

            if (scalingTimeElapsed >= scalingDuration)
            {
                SceneHistoryManager.LoadScene(nextSceneName);
            }
        }
    }

    public void StartScaling()
    {
        isScaling = true;
        scalingTimeElapsed = 0f;
    }

    public void CancelScaling()
    {
        isScaling = false;
        scalingTimeElapsed = 0f;
        targetObject.transform.localScale = initialScale;
    }
}
