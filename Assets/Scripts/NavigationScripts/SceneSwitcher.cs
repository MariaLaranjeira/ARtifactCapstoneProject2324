using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    [SerializeField]
    private string sceneName;

    public void switchScene() {
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
}
