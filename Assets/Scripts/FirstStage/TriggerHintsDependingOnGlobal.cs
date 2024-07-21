using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerHintsDependingOnGlobal : MonoBehaviour
{

    public GameObject[] hints;

    // Start is called before the first frame update
    void Start()
    {
        if (!FirstStageGlobalState.helpButton) {
            foreach (GameObject hint in hints) {
                hint.SetActive(true);
            }
        } else {
            foreach (GameObject hint in hints) {
                hint.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
