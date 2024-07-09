using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageSelector : MonoBehaviour
{
    public Image imageObject;
    public Sprite[] imageList;
    public Button buttonLeft;
    public Button buttonRight;
    public Button buttonSelect;

    private int currentIndex = 0;

    void Start()
    {
        if (imageList.Length > 0)
        {
            imageObject.sprite = imageList[currentIndex];
        }

        buttonLeft.onClick.AddListener(SelectPreviousImage);
        buttonRight.onClick.AddListener(SelectNextImage);
        buttonSelect.onClick.AddListener(SelectImage);
    }

    void SelectPreviousImage()
    {
        if (imageList.Length > 0)
        {
            currentIndex--;
            if (currentIndex < 0)
            {
                currentIndex = imageList.Length - 1;
            }
            imageObject.sprite = imageList[currentIndex];
        }
    }

    void SelectNextImage()
    {
        if (imageList.Length > 0)
        {
            currentIndex++;
            if (currentIndex >= imageList.Length)
            {
                currentIndex = 0;
            }
            imageObject.sprite = imageList[currentIndex];
        }
    }

    void SelectImage()
    {
        FirstStageGlobalState.characterSelected = currentIndex;
    }
}

