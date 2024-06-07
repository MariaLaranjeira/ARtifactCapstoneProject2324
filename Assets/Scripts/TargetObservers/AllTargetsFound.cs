using UnityEngine;
using Vuforia;
using UnityEngine.UI;
using System.Collections.Generic;

public class AllTargetsFound : MonoBehaviour
{
    public UnityEngine.UI.Image targetImage; // The image to show when all targets are found
    public List<ObserverBehaviour> imageTargets; // List of image targets to track

    private void Start()
    {
        // Hide the image initially
        if (targetImage != null)
        {
            targetImage.gameObject.SetActive(false);
        }

        // Register to trackable events for each image target
        foreach (var target in imageTargets)
        {
            target.OnTargetStatusChanged += OnTargetStatusChanged;
        }
    }

    private void OnDestroy()
    {
        // Unregister from trackable events when the object is destroyed
        foreach (var target in imageTargets)
        {
            target.OnTargetStatusChanged -= OnTargetStatusChanged;
        }
    }

    private void OnTargetStatusChanged(ObserverBehaviour behaviour, TargetStatus status)
    {
        // Check if all targets are tracked
        bool allTargetsTracked = true;
        foreach (var target in imageTargets)
        {
            if (target.TargetStatus.Status != Status.TRACKED && target.TargetStatus.Status != Status.EXTENDED_TRACKED)
            {
                allTargetsTracked = false;
                break;
            }
        }

        // Show or hide the image based on the tracking state of all targets
        if (targetImage != null)
        {
            targetImage.gameObject.SetActive(allTargetsTracked);
        }
    }
}
