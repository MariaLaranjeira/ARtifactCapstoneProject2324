using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RetractableMenu : MonoBehaviour
{
    public RectTransform bottomMenu; // Reference to the RectTransform of the bottom menu
    public float hiddenPositionY = -100f; // The Y position when hidden
    public float visiblePositionY = 0f; // The Y position when visible
    public float animationDuration = 0.5f; // Duration of the animation

    private bool isMenuVisible = false;
    private Vector2 hiddenPosition;
    private Vector2 visiblePosition;

    void Start()
    {
        // Set initial positions
        hiddenPosition = new Vector2(bottomMenu.anchoredPosition.x, hiddenPositionY);
        visiblePosition = new Vector2(bottomMenu.anchoredPosition.x, visiblePositionY);
        
        // Initialize the menu position to hidden
        bottomMenu.anchoredPosition = hiddenPosition;
    }

    public void ToggleMenu()
    {
        StopAllCoroutines(); // Stop any ongoing animations
        StartCoroutine(AnimateMenu(isMenuVisible ? hiddenPosition : visiblePosition));
        isMenuVisible = !isMenuVisible;
    }

    private IEnumerator AnimateMenu(Vector2 targetPosition)
    {
        float elapsedTime = 0f;
        Vector2 startingPosition = bottomMenu.anchoredPosition;

        while (elapsedTime < animationDuration)
        {
            bottomMenu.anchoredPosition = Vector2.Lerp(startingPosition, targetPosition, elapsedTime / animationDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        bottomMenu.anchoredPosition = targetPosition;
    }
}
