using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class SaveImageToGallery : MonoBehaviour
{
    public RawImage rawImage; // Assign this in the Inspector

    public void Save()
    {
        // Convert the RawImage texture to a Texture2D
        Texture2D texture = rawImage.texture as Texture2D;

        // If the texture is RenderTexture, convert it to Texture2D
        if (texture == null && rawImage.texture is RenderTexture)
        {
            RenderTexture renderTexture = rawImage.texture as RenderTexture;
            texture = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.RGB24, false);
            RenderTexture.active = renderTexture;
            texture.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
            texture.Apply();
            RenderTexture.active = null;
        }

        // Save the texture to a temporary file
        string path = Path.Combine(Application.temporaryCachePath, "saved_image.png");
        File.WriteAllBytes(path, texture.EncodeToPNG());

        // Use NativeGallery plugin to save the image to the gallery
        NativeGallery.Permission permission = NativeGallery.SaveImageToGallery(path, "MyAppGallery", "Image_{0}.png");
        Debug.Log("Permission result: " + permission);

        // Do not destroy the texture
    }
}
