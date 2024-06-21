using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class screenshotPuzzle : MonoBehaviour
{
    public GameObject scenery;
    private Vector2 sceneryPosition;
    public Button captureButton;
    public RawImage screenshotDisplay;
    public Camera arCamera;

    private void Start()
    {
        if (captureButton != null)
        {
            captureButton.onClick.AddListener(CaptureScreenshot);
        }
        else
        {
            Debug.LogError("CaptureButton is not assigned.");
        }
    }

    private void CaptureScreenshot()
    {
        StartCoroutine(CaptureScreenshotCoroutine());
    }

    private IEnumerator CaptureScreenshotCoroutine()
    {
        yield return new WaitForEndOfFrame();

        Canvas.ForceUpdateCanvases();

        RectTransform rectTransform = scenery.GetComponent<RectTransform>();

        // Assuming this RectTransform is part of a Canvas
        Canvas canvas = GetComponentInParent<Canvas>();

        // Get the scale factor of the canvas
        float scaleFactor = canvas.scaleFactor;

        Debug.Log("Scale factor: " + scaleFactor);

        // Convert width and height from Unity units to pixels
        float width = rectTransform.rect.width * scaleFactor;
        float height = rectTransform.rect.height * scaleFactor;
        Debug.Log("Width in pixels: " + width + " Height in pixels: " + height);
        Debug.Log("Width in Unity units: " + Screen.width + " Height in Unity units: " + Screen.height);

        sceneryPosition = RectTransformUtility.WorldToScreenPoint(null, rectTransform.position);

        RenderTexture renderTexture = new RenderTexture(Screen.width, Screen.height, 24);
        arCamera.targetTexture = renderTexture;
        Texture2D screenShot = new Texture2D((int)width, (int)height, TextureFormat.RGB24, false);
        arCamera.Render();

        RenderTexture.active = renderTexture;
        Vector3[] worldCorners = new Vector3[4];
        rectTransform.GetWorldCorners(worldCorners);
        Vector3 bottomLeftPosition = worldCorners[0]; // Bottom-left corner in world space

        // Convert bottom-left world position to screen space
        //Vector2 bottomLeftPosition = RectTransformUtility.WorldToScreenPoint(null, bottomLeftWorld);

        Debug.Log("Bottom left position in screen space: " + bottomLeftPosition);
        int x = (Screen.width - (int)width) / 2;
        screenShot.ReadPixels(new Rect(x, bottomLeftPosition.y, width, height - 15), 0, 0);
        screenShot.Apply();

        arCamera.targetTexture = null;
        RenderTexture.active = null;
        Destroy(renderTexture);

        screenshotDisplay.texture = screenShot;
        screenshotDisplay.gameObject.SetActive(true);

        // Optionally save the screenshot to a file
        byte[] bytes = screenShot.EncodeToPNG();
        string path = Path.Combine(Application.persistentDataPath, "Puzzle_Screenshot.png");
        File.WriteAllBytes(path, bytes);

        Debug.Log("Screenshot captured and saved to: " + path);
    }
}