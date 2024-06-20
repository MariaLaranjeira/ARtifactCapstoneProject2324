using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideCameraPrompt : MonoBehaviour
{

    public GameObject cameraPrompt;

    public void HidePrompt()
    {
        cameraPrompt.SetActive(false);
    }

    public void ShowPrompt()
    {
        cameraPrompt.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
