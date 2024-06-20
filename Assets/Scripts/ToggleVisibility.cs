using UnityEngine;

public class ToggleVisibility : MonoBehaviour
{
    public GameObject[] objectsToDisappear; // Objects to make invisible
    public GameObject[] objectsToAppear; // Objects to make visible

    public void Toggle()
    {
        // Make objects disappear
        foreach (GameObject obj in objectsToDisappear)
        {
            obj.SetActive(false);
        }

        // Make objects appear
        foreach (GameObject obj in objectsToAppear)
        {
            obj.SetActive(true);
        }
    }
}
