using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class screenshotPuzzle : MonoBehaviour
{
    public GameObject scenery;
    private Vector2 sceneryDimensions;
    public Button captureButton;
    public RawImage screenshotDisplay;
    public Camera mainCamera;

    private void Start()
    {
        RectTransform sceneryRectTransform = scenery.GetComponent<RectTransform>();
        Vector2 sceneryDimensions = Vector2.zero;
        sceneryDimensions = sceneryRectTransform.sizeDelta;
    }

    public void TakeScreenshot()
    {
        StartCoroutine(CaptureScreenshotCoroutine());
    }

    private IEnumerator CaptureScreenshotCoroutine()
    {
        yield return new WaitForEndOfFrame();

        RenderTexture renderTexture = new RenderTexture(Screen.width, Screen.height, 24);
        Camera.main.targetTexture = renderTexture;
        Texture2D screenShot = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        Camera.main.Render();

        RenderTexture.active = renderTexture;
        screenShot.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        screenShot.Apply();

        screenshotDisplay.texture = screenShot;
        screenshotDisplay.gameObject.SetActive(true);

        // Save the screenshot to a file
        byte[] bytes = screenShot.EncodeToPNG();
        string path = Path.Combine(Application.persistentDataPath, "Puzzle_Screenshot.png");
        File.WriteAllBytes(path, bytes);

        Debug.Log("Screenshot captured and saved to: " + path);
    }
}
