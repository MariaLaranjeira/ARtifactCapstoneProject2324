using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeGesture : MonoBehaviour
{
    public static bool swipeDetected = false;

    [SerializeField] private Touch touch;
    private Material[] materials;
    private Material[] newMaterials; // Moved here to make it accessible in the entire class
    
    private int currentMaterialIndex;
    private Renderer meshRenderer;

    private Vector2 startTouchPosition, endTouchPosition;
    private const float minSwipeDistance = 50f; // Minimum distance required for a swipe gesture

    void Start()
    {
        // Load materials from Resources folder
        materials = Resources.LoadAll<Material>("Materials");
        Debug.Log("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
        Debug.Log(materials.Length);

        // Find the mesh renderer within Group3 inside Group1
        Transform group1Transform = transform.Find("Group1");
        
        if (group1Transform != null)
        {
            Transform group3Transform = group1Transform.Find("Group3");
            if (group3Transform != null)
            {
                meshRenderer = group3Transform.GetComponentInChildren<Renderer>();
                if (meshRenderer == null)
                {
                    Debug.LogError("Mesh Renderer not found in Group3.");
                }
            }
            else
            {
                Debug.LogError("Group3 not found in Group1.");
            }
        }
        else
        {
            Debug.LogError("Group1 not found.");
        }
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            SwipeGesture.swipeDetected = false;

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    startTouchPosition = touch.position;
                    break;
                case TouchPhase.Ended:
                    endTouchPosition = touch.position;

                    float swipeDistanceX = endTouchPosition.x - startTouchPosition.x;
                    float swipeDistanceY = endTouchPosition.y - startTouchPosition.y;

                    if (Mathf.Abs(swipeDistanceX) > minSwipeDistance)
                    {
                        if (swipeDistanceX > 0)
                        {
                            ChangeMaterial(1); // Swipe right
                            Debug.Log("Swipe Right!");
                            Debug.Log(materials.Length);
                        }
                        else
                        {
                            ChangeMaterial(-1); // Swipe left
                            Debug.Log("Swipe Left!");
                            Debug.Log(materials.Length);
                        }
                    }

                    break;
            }
        }
    }

    void ChangeMaterial(int direction)
    {
        if (materials != null && materials.Length > 0)
        {
            Debug.Log(meshRenderer.name);
            currentMaterialIndex += direction;
            currentMaterialIndex = (currentMaterialIndex + materials.Length) % materials.Length;

            if (meshRenderer != null)
            {
                // Initialize newMaterials array with size 2
                newMaterials = new Material[2];

                // Assign materials to newMaterials
                newMaterials[0] = materials[currentMaterialIndex]; // Assigning to the first slot
                newMaterials[1] = materials[currentMaterialIndex]; // Assigning to the second slot

                // Assign newMaterials to the mesh renderer
                meshRenderer.materials = newMaterials;
            }
            else
            {
                Debug.LogError("Mesh Renderer is null.");
            }
        }
        else
        {
            Debug.LogWarning("No materials loaded.");
        }
    }
}
