using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminateFirstStageLevel : MonoBehaviour
{

    public string sceneName;

    // Start is called before the first frame update
    void Start()
    {
        FirstStageGlobalState.initialInteractionCompleted = true;
        NavigationManager.NextLevel();

        if (!string.IsNullOrEmpty(sceneName)) {
            if (sceneName == "main") {
                SceneHistoryManager.JumpToNavigationPage();
            } else {
                SceneHistoryManager.LoadScene(sceneName);
            }
        } else {
            Debug.LogError("Scene name is empty");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
