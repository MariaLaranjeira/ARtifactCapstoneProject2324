using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ARScriptManager : MonoBehaviour
{
    [System.Serializable]
    public class ScriptButtonPair
    {
        public MonoBehaviour script;
        public Button button;
    }

    public List<ScriptButtonPair> scriptButtonPairs;

    void Start()
    {
        // Ensure all scripts are initially deactivated
        foreach (var pair in scriptButtonPairs)
        {
            if (pair.script != null)
            {
                pair.script.enabled = false;
            }

            if (pair.button != null)
            {
                Button localButton = pair.button; // Local copy to prevent closure issues
                MonoBehaviour localScript = pair.script; // Local copy to prevent closure issues

                localButton.onClick.AddListener(() => ActivateScript(localScript));
            }
        }
    }

    void ActivateScript(MonoBehaviour scriptToActivate)
    {
        // Deactivate all scripts first
        foreach (var pair in scriptButtonPairs)
        {
            if (pair.script != null)
            {
                pair.script.enabled = false;
            }
        }

        // Activate the selected script
        if (scriptToActivate != null)
        {
            scriptToActivate.enabled = true;
        }
    }
}
