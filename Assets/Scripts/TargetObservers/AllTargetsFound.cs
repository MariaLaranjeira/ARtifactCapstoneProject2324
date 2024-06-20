using UnityEngine;
using Vuforia;
using System.Collections.Generic;

public class AllTargetsFound : MonoBehaviour
{
    public List<ObserverBehaviour> imageTargets; // List of image targets to track
    public ToggleVisibility toggleVisibility; // Reference to the ToggleVisibility script
    private void Start()
    {
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

        // Toggle visibility if all targets are tracked
        if (allTargetsTracked && toggleVisibility != null)
        {
            if (!REDGlobalState.incrementedLevelRED) {
                NavigationManager.NextLevel();
                REDGlobalState.incrementedLevelRED = true;
            }
            toggleVisibility.Toggle();
        }
    }
}
