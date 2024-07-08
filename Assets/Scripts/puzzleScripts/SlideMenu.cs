using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideMenu : MonoBehaviour
{
    public Canvas canvas;
    public RectTransform menu;
    public GameObject Piece_menu;
    public bool isMenuOpen = false;
    private float menuHeight;
    private int canvasHeight;
    public GameObject captureButton;

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
        menu.anchoredPosition = new Vector2(0, -canvasHeight + menuHeight / 4);
        Piece_menu.SetActive(false);
        captureButton.SetActive(false);
        Debug.Log("Open Menu");
        isMenuOpen = true;
    }

    public void CloseMenu()
    {
        menu.anchoredPosition = new Vector2(0 , -canvasHeight - menuHeight / 2);
        Piece_menu.SetActive(true);
        Debug.Log("Close Menu");
        isMenuOpen = false;
    }
}
