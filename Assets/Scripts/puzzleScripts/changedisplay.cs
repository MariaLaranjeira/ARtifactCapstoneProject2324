using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class changedisplay : MonoBehaviour
{
        private GameObject scenery;
        bool isSceneryActive = true;
    // Update is called once per frame
    public void makeHidden()
    {
        if(isSceneryActive)
        {
            scenery = GameObject.Find("IntroScene");
            scenery.SetActive(false);
            scenery = GameObject.Find("IntroScene");
            scenery.SetActive(false);
            isSceneryActive = false;
        }
    }
}
