using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleUntoggleVisibility : MonoBehaviour
{
    // Reference to the GameObject to toggle
    public GameObject targetObject;

    // Method to toggle visibility
    public void Toggle()
    {
        if (targetObject != null)
        {
            // Toggle the active state of the targetObject
            targetObject.SetActive(!targetObject.activeSelf);
        }
    }    
}
