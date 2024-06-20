using UnityEngine;

[RequireComponent(typeof(Camera))]
public class KaleidoscopeEffect : MonoBehaviour
{
    public Material kaleidoscopeMaterial;
    [Range(1, 12)]
    public int segments = 6;

    private void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        if (kaleidoscopeMaterial != null)
        {
            kaleidoscopeMaterial.SetFloat("_Segments", segments);
            Graphics.Blit(src, dest, kaleidoscopeMaterial);
        }
        else
        {
            Graphics.Blit(src, dest);
        }
    }
}
