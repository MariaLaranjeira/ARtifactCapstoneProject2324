using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class PlaceObjectOnGround : MonoBehaviour
{
    public GameObject objectToPlace;
    private bool isPlaced = false;

    void Start()
    {
        if (objectToPlace != null)
        {
            objectToPlace.SetActive(false);
        }
    }

    public void OnInteractiveHitTest(HitTestResult result)
    {
        if (!isPlaced && objectToPlace != null)
        {
            objectToPlace.SetActive(true);
            objectToPlace.transform.position = result.Position;
            objectToPlace.transform.rotation = result.Rotation;
            isPlaced = true;
        }
    }
}
