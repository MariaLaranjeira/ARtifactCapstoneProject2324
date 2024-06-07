using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class CustomObserverEventHandler : DefaultObserverEventHandler
{
    public UnityEngine.UI.Image imageObject; // The UI Image object that you want to change the sprite of
    public Sprite newSprite; // The new sprite that you want to set when the target is found

    protected override void OnTrackingFound()
    {
        base.OnTrackingFound();
        Debug.Log("Target Found");
        if (imageObject != null && newSprite != null)
        {
            imageObject.sprite = newSprite;
        }
    }

    protected override void OnTrackingLost()
    {
        base.OnTrackingLost();
        Debug.Log("Target Lost");
        // Optional: Handle target lost event here if needed
    }
}
