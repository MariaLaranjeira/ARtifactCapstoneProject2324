using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using Vuforia;

public class TrackingStatusHandler : MonoBehaviour
{
    public GameObject QuizPanel;
    public TextMeshProUGUI statusText;
    public float popUpDuration = 0.5f; // Duration of the pop-up animation
    private ObserverBehaviour mObserverBehaviour;
    private CanvasGroup canvasGroup;
    private Vector3 originalScale;

    void Start()
    {
        mObserverBehaviour = GetComponent<ObserverBehaviour>();
        canvasGroup = QuizPanel.GetComponent<CanvasGroup>();
        originalScale = QuizPanel.transform.localScale;

        if (mObserverBehaviour == null)
        {
            Debug.LogError("ObserverBehaviour component not found.");
        }
        if (canvasGroup == null)
        {
            Debug.LogError("CanvasGroup component not found on QuizPanel.");
        }

        QuizPanel.SetActive(false); // Ensure the panel starts off hidden
    }

    void Update()
    {
        if (mObserverBehaviour != null)
        {
            if (mObserverBehaviour.TargetStatus.Status == Status.TRACKED)
            {
                if (!QuizPanel.activeSelf)
                {
                    QuizPanel.SetActive(true);
                    StartCoroutine(PopUpPanel());
                }
                statusText.gameObject.SetActive(false);
                Debug.Log("Tracking status: " + statusText.text);
            }
            else
            {
                statusText.gameObject.SetActive(true);
            }
        }
    }

    IEnumerator PopUpPanel()
    {
        QuizPanel.transform.localScale = Vector3.zero; // Start scale at zero
        canvasGroup.alpha = 0; // Start with transparent panel

        float elapsedTime = 0f;

        while (elapsedTime < popUpDuration)
        {
            float t = elapsedTime / popUpDuration;
            QuizPanel.transform.localScale = Vector3.Lerp(Vector3.zero, originalScale, t);
            canvasGroup.alpha = Mathf.Lerp(0, 1, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        QuizPanel.transform.localScale = originalScale; // Ensure it ends at original scale
        canvasGroup.alpha = 1; // Ensure it ends fully visible
    }
}