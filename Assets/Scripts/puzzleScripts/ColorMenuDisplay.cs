using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorMenuDisplay : MonoBehaviour
{
    public Canvas canvas;
    public RectTransform menu;
    private float menuHeight;
    public int canvasHeight;

    void Start()
    {
        menuHeight = menu.rect.height;
        canvasHeight = (int)canvas.pixelRect.height / 2;
        CloseMenu();
    }

    public void OpenMenu()
    {
        menu.anchoredPosition = new Vector2(0, -canvasHeight + menuHeight / 2);
    }

    public void CloseMenu()
    {
        menu.anchoredPosition = new Vector2(0 , -canvasHeight - menuHeight / 2);
    }
}
