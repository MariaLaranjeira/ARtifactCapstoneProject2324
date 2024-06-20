using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class REDGlobalState
{
    public static bool incrementedLevelRED = false;

    public static void ResetState()
    {
        incrementedLevelRED = false;
    }
}
