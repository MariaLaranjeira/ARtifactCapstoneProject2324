using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class changedisplay : MonoBehaviour
{
    private GameObject scenery;
    public GameObject piece;
    // Update is called once per frame
    public void makeHidden()
    {
        scenery = GameObject.Find("IntroScene");
        scenery.SetActive(false);
        piece.SetActive(true);
    }
}
