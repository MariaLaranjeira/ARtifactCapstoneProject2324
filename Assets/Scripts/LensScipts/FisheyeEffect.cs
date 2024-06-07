using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
public class FisheyeEffect : MonoBehaviour
{
    public Material fisheyeMaterial;
    [Range(0, 2)] // Increased maximum range
    public float strength = 1.0f;
    [Range(0, 1)]
    public float radius = 0.5f;
    [Range(0, 1)]
    public float effectRadius = 0.5f;

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if (fisheyeMaterial != null)
        {
            fisheyeMaterial.SetFloat("_Strength", strength);
            fisheyeMaterial.SetFloat("_Radius", radius);
            fisheyeMaterial.SetFloat("_EffectRadius", effectRadius);
            Graphics.Blit(source, destination, fisheyeMaterial);
        }
        else
        {
            Graphics.Blit(source, destination);
        }
    }
}
