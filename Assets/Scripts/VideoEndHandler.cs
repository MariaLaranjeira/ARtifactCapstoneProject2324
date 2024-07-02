using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using System.Collections;

public class VideoEndHandler : MonoBehaviour
{
    public VideoPlayer videoPlayer; // The VideoPlayer component
    public GameObject screen; // The screen GameObject to hide
    public float fadeDuration = 1.0f; // Duration of the fade

    private RawImage rawImage; // The RawImage component of the screen

    void Start()
    {
        if (videoPlayer == null)
        {
            videoPlayer = GetComponent<VideoPlayer>();
        }

        if (videoPlayer != null)
        {
            videoPlayer.loopPointReached += OnVideoEnd; // Subscribe to the event
        }

        if (screen != null)
        {
            rawImage = screen.GetComponent<RawImage>();
            if (rawImage == null)
            {
                Debug.LogError("RawImage component not found on the screen GameObject.");
            }
        }
    }

    void OnDestroy()
    {
        if (videoPlayer != null)
        {
            videoPlayer.loopPointReached -= OnVideoEnd; // Unsubscribe from the event
        }
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        if (screen != null)
        {
            StartCoroutine(FadeOutScreen());
        }
    }

    IEnumerator FadeOutScreen()
    {
        float startAlpha = rawImage.color.a;
        float time = 0;

        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, 0, time / fadeDuration);
            Color newColor = rawImage.color;
            newColor.a = alpha;
            rawImage.color = newColor;
            yield return null;
        }

        // Ensure the final alpha is set to 0
        Color finalColor = rawImage.color;
        finalColor.a = 0;
        rawImage.color = finalColor;

        // Optionally, deactivate the screen GameObject
        screen.SetActive(false);
    }
}
