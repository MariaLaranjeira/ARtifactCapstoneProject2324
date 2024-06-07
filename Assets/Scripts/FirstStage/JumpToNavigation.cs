using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpToNavigation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        NavigationManager.NextLevel();
        SceneHistoryManager.JumpToNavigationPage();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
