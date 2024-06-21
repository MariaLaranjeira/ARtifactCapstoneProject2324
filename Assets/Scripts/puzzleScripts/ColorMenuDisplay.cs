using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorMenuDisplay : MonoBehaviour
{
    public Canvas canvas;
    public RectTransform menu;
    private float menuHeight;
    public int canvasHeight;
    public GameObject Piece_menu;
    private bool firstTime = true;

    void Start()
    {
        menuHeight = menu.rect.height;
        canvasHeight = (int)canvas.pixelRect.height / 2;
        if(firstTime)
        {
            menu.anchoredPosition = new Vector2(0 , -canvasHeight - menuHeight / 2);
            firstTime = false;
        }
    }

    public void OpenMenu()
    {
        menu.anchoredPosition = new Vector2(0, -canvasHeight + menuHeight / 2);
        Piece_menu.SetActive(false);
    }

    public void CloseMenu()
    {
        menu.anchoredPosition = new Vector2(0 , -canvasHeight - menuHeight / 2);
        Piece_menu.SetActive(true);
    }
}
