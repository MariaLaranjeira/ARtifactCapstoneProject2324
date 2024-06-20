using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenShotScript : MonoBehaviour
{
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

        RenderTexture renderTexture = new RenderTexture(Screen.width, Screen.height, 24);
        arCamera.targetTexture = renderTexture;
        Texture2D screenShot = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        arCamera.Render();

        RenderTexture.active = renderTexture;
        screenShot.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        screenShot.Apply();

        arCamera.targetTexture = null;
        RenderTexture.active = null;
        Destroy(renderTexture);

        
        screenshotDisplay.texture = screenShot;
        screenshotDisplay.gameObject.SetActive(true);

        // Optionally save the screenshot to a file
        byte[] bytes = screenShot.EncodeToPNG();
        string path = Path.Combine(Application.persistentDataPath, "AR_Screenshot.png");
        File.WriteAllBytes(path, bytes);

        Debug.Log("Screenshot captured and saved to: " + path);
    }
}
