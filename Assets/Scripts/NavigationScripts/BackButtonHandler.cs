using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButtonHandler : MonoBehaviour
{

    void HandleBackButton()
    {
        SceneHistoryManager.LoadPreviousScene();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            HandleBackButton();
        }
    }
}
