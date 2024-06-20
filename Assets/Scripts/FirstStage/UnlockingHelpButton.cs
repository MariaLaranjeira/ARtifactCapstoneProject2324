using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockingHelpButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FirstStageGlobalState.helpButton = true;
        GlobalGameStateManager.SaveGameState();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
