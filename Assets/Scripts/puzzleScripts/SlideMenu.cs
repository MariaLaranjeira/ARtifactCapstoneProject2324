using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideMenu : MonoBehaviour
{
    public Canvas canvas;
    public RectTransform menu;
    public bool isMenuOpen = false;
    private float menuHeight;
    public int canvasHeight;

    void Start()
    {
        menuHeight = menu.rect.height;
        canvasHeight = (int)canvas.pixelRect.height / 2;
        CloseMenu();
    }

    public void OnClick()
    {
        if (isMenuOpen)
        {
            CloseMenu();
            isMenuOpen = false;
        }
        else
        {
            OpenMenu();
            isMenuOpen = true;
        }
    }

    public void OpenMenu()
    {
        menu.anchoredPosition = new Vector2(0, -canvasHeight + menuHeight / 2);
        isMenuOpen = true;
    }

    public void CloseMenu()
    {
        menu.anchoredPosition = new Vector2(0 , -canvasHeight - menuHeight / 2 + 150);
        isMenuOpen = false;
    }
}
