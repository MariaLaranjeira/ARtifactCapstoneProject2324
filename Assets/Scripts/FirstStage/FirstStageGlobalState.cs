using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FirstStageGlobalState
{
    public static bool initialInteractionCompleted = false;
    public static bool helpButton = false;

    // Temp, should probably be a variable of another type
    public static string playerChoice = "";

    public static void ResetState()
    {
        initialInteractionCompleted = false;
        helpButton = false;
        playerChoice = "";
    }
}
 
