using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeToPath : MonoBehaviour
{
    [SerializeField]
    private string sceneName;

    public void start() {

    }

    public void update() {

    }

    public void switchScene() {
        if (!string.IsNullOrEmpty(sceneName)) {
            SceneManager.LoadScene(sceneName);
        } else {
            Debug.LogError("Scene name is empty");
        }
    }
}
