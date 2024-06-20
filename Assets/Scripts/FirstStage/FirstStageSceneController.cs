using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstStageSceneController : MonoBehaviour
{
    public string initialInteractionSceneName = "InitialInteractionScene"; // Name of the initial interaction scene
    public string mainSceneName = "MainScene"; // Name of the main playable scene

    private void Start()
    {
        // Check if the initial interaction has been completed
        if (FirstStageGlobalState.initialInteractionCompleted)
        {
            // If completed, load the main scene directly
            SceneHistoryManager.LoadScene(mainSceneName);
        }
        else
        {
            // If not completed, load the initial interaction scene
            SceneHistoryManager.LoadScene(initialInteractionSceneName);
        }

        // Todo: remove the dummy from the history stack
    }

    // Call this method when the initial interaction is completed
    public void CompleteInitialInteraction(string choice)
    {
        // Update the global state
        FirstStageGlobalState.initialInteractionCompleted = true;
        FirstStageGlobalState.playerChoice = choice;
    }
}
