using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class FadePanel : MonoBehaviour, IPointerClickHandler
{
    private CanvasGroup canvasGroup;
    public float fadeDuration = 1.0f; // Duration of the fade in seconds
    private bool isFading = false;

    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            Debug.LogError("CanvasGroup component is missing from the panel.");
        }
    }

    void Update()
    {
        if (isFading)
        {
            // Gradually decrease the alpha value of the CanvasGroup
            canvasGroup.alpha -= Time.deltaTime / fadeDuration;

            // Once the alpha is 0 or less, the panel is fully transparent
            if (canvasGroup.alpha <= 0)
            {
                isFading = false;
                canvasGroup.alpha = 0; // Ensure alpha is set to 0
                gameObject.SetActive(false); // Optionally, deactivate the panel
            }
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!isFading)
        {
            isFading = true;
        }
    }
}
