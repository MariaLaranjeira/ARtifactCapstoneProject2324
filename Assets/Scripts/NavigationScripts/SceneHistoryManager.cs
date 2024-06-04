using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHistoryManager : MonoBehaviour
{

    private static Stack<string> sceneHistory = new Stack<string>();    

    public static void LoadScene(string sceneName)
    {
        if (SceneManager.GetActiveScene().name != "exit")
        {
            sceneHistory.Push(SceneManager.GetActiveScene().name);
        }

        SceneManager.LoadScene(sceneName);
    }

    public static void LoadPreviousScene()
    {
        if (sceneHistory.Count > 0)
        {
            string previousScene = sceneHistory.Pop();
            SceneManager.LoadScene(previousScene);
        }
        else 
        {
            Debug.LogWarning("No previous scene in history. Exiting application.");
            Application.Quit();
        }
    }

    public static void JumpToNavigationPage()
    {
        while (sceneHistory.Count > 0)
        {
            string previousScene = sceneHistory.Pop();
            if (previousScene == "NavigationPage")
            {
                SceneManager.LoadScene(previousScene);
                return;
            }
        }

        Debug.LogWarning("NavigationPage not found in history. Loading it directly.");
        SceneManager.LoadScene("NavigationPage");
    }
}
