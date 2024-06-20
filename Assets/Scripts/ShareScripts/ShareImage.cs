using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ShareImage : MonoBehaviour
{
    public RawImage rawImage; // Assign this in the Inspector

    public void Share()
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
        string path = Path.Combine(Application.temporaryCachePath, "shared_image.png");
        File.WriteAllBytes(path, texture.EncodeToPNG());

        // Use NativeShare plugin to share the image
        new NativeShare().AddFile(path).SetSubject("Check this out!").SetText("Hey, check out this image!").Share();

        // Do not destroy the texture
    }
}
