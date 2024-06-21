using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class changedisplay : MonoBehaviour
{
    private GameObject scenery;
    public GameObject piece;
    
    public GameObject introText;

    void Start()
    {
        Invoke("makeVisible", 2);
    }
    public void makeHidden()
    {
        scenery = GameObject.Find("IntroScene");
        scenery.SetActive(false);
        piece.SetActive(false);
    }

    public void makeVisible()
    {
        introText.SetActive(true);
    }
}
