using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class changedisplay : MonoBehaviour
{
    private GameObject scenery;
    public GameObject piecesExplosion;
    public GameObject pieceMenu;
    
    public GameObject introText;

    void Start()
    {
        pieceMenu.SetActive(false);
        Invoke("makeVisible", 1.0f);
    }
    public void makeHidden()
    {
        scenery = GameObject.Find("IntroScene");
        scenery.SetActive(false);
        piecesExplosion.SetActive(false);
        pieceMenu.SetActive(true);
    }

    public void makeVisible()
    {
        introText.SetActive(true);
    }
}
