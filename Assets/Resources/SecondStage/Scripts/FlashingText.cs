using UnityEngine;
using TMPro;
using System.Collections;

public class FlashingText : MonoBehaviour
{
    public TextMeshProUGUI textToFlash;
    public int baseFontSize = 12;
    public int fontSizeVariance = 3;
    public float flashSpeed;

    void Start()
    {
        if (textToFlash == null)
        {
            Debug.LogError("TextMeshProUGUI component not assigned.");
            return;
        }

        textToFlash.fontSize = baseFontSize;
        flashSpeed = 1;

        StartCoroutine(FlashText());
    }

    IEnumerator FlashText()
    {
        while (true)
        {
            while (textToFlash.fontSize < baseFontSize + fontSizeVariance)
            {
                textToFlash.fontSize += Time.deltaTime * flashSpeed * fontSizeVariance;
                yield return null;
            }

            while (textToFlash.fontSize > baseFontSize)
            {
                textToFlash.fontSize -= Time.deltaTime * flashSpeed * fontSizeVariance;
                yield return null;
            }
        }
    }

}
