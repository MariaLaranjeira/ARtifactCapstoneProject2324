using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FunFactsScript : MonoBehaviour
{
    public GameObject targetObject;
    public float animationDuration = 1f;
    public float delayBeforeScaling = 0.5f; // Public variable to determine delay before scaling
    public GameObject logo;
    public GameObject chispas;

    public float fadeDuration = 1.0f;

    private Vector3 targetScale;
    private Vector3 initialScale;
    private bool isAnimating = false;
    private bool isShowing = false;
    private bool isFading = false;
    private CanvasGroup canvasGroup;

    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            Debug.LogError("FunFactsScript: CanvasGroup component is missing from the panel.");
        }

        if (targetObject != null)
        {
            targetScale = targetObject.transform.localScale;
            initialScale = new Vector3(0, 0, 0); // Ensure initial scale is captured correctly
            targetObject.transform.localScale = initialScale;
        }
    }

    void Update()
    {
        if (isFading)
        {
            canvasGroup.alpha -= Time.deltaTime / fadeDuration;

            if (canvasGroup.alpha <= 0)
            {
                isFading = false;
                canvasGroup.alpha = 0;
                targetObject.SetActive(false); // Disable the targetObject
            }
        }
    }

    public void TriggerShowObject()
    {
        if (targetObject != null && !isAnimating)
        {
            targetObject.SetActive(true);
            StartCoroutine(ShowObjectCoroutine());
        }
    }

    private IEnumerator ShowObjectCoroutine()
    {
        isAnimating = true;
        float elapsedTime = 0f;
        targetObject.transform.localScale = initialScale; // Reset to initial scale before starting

        // Ensure the alpha is reset before starting the animation
        canvasGroup.alpha = 1f;

        // Wait for the delay before starting the scale animation
        yield return new WaitForSeconds(delayBeforeScaling);

        while (elapsedTime < animationDuration)
        {
            targetObject.transform.localScale = Vector3.Lerp(initialScale, targetScale, elapsedTime / animationDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        targetObject.transform.localScale = targetScale;
        isAnimating = false;
        isShowing = true;
    }

    public void FadeAndReset()
    {
        if (!isFading)
        {
            isFading = true;
        }

        if (logo != null)
        {
            var logoRotation = logo.GetComponent<TriggerLogoRotationAtClick>();
            if (logoRotation != null)
            {
                logoRotation.reset();
            }

            var logoSpawn = logo.GetComponent<TriggerSpawnAtClick>();
            if (logoSpawn != null)
            {
                logoSpawn.resetScale();
            }

            var logoButton = logo.GetComponent<Button>();
            if (logoButton != null)
            {
                logoButton.enabled = true;
            }
        }

        if (chispas != null)
        {
            var chispasSpawn = chispas.GetComponent<TriggerSpawnAtClick>();
            if (chispasSpawn != null)
            {
                chispasSpawn.resetScale();
            }
        }
    }
}
