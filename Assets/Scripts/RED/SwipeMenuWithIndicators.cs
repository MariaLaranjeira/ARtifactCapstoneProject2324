using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwipeMenuWithIndicators : MonoBehaviour
{
    public GameObject scrollbar;
    public GameObject[] indicators; // Array to hold the indicator circles
    public float enlargedSize = 20f; // The enlarged size for the active indicator
    public float normalSize = 10f; // The normal size for the inactive indicators
    public Sprite selectedSprite; // The sprite for the selected circle
    public Sprite normalSprite; // The sprite for the normal circles

    private float scroll_pos = 0;
    private float[] pos;

    // Use this for initialization
    void Start()
    {
        UpdateIndicators(0); // Initialize the first indicator as active
    }

    // Update is called once per frame
    void Update()
    {
        pos = new float[transform.childCount];
        float distance = 1f / (pos.Length - 1f);
        for (int i = 0; i < pos.Length; i++)
        {
            pos[i] = distance * i;
        }

        if (Input.GetMouseButton(0))
        {
            scroll_pos = scrollbar.GetComponent<Scrollbar>().value;
        }
        else
        {
            for (int i = 0; i < pos.Length; i++)
            {
                if (scroll_pos < pos[i] + (distance / 2) && scroll_pos > pos[i] - (distance / 2))
                {
                    scrollbar.GetComponent<Scrollbar>().value = Mathf.Lerp(scrollbar.GetComponent<Scrollbar>().value, pos[i], 0.1f);
                    UpdateIndicators(i); // Update the indicators based on the current position
                }
            }
        }
    }

    // Method to update the size and sprite of the indicators
    private void UpdateIndicators(int currentIndex)
    {
        for (int i = 0; i < indicators.Length; i++)
        {
            RectTransform rectTransform = indicators[i].GetComponent<RectTransform>();
            Image image = indicators[i].GetComponent<Image>();

            if (i == currentIndex)
            {
                rectTransform.sizeDelta = new Vector2(enlargedSize, enlargedSize);
                image.sprite = selectedSprite;
            }
            else
            {
                rectTransform.sizeDelta = new Vector2(normalSize, normalSize);
                image.sprite = normalSprite;
            }
        }
    }
}
