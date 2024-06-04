using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LanguageDependentText : MonoBehaviour
{
    public string englishText;
    public string portugueseText;
    private TMP_Text tmpText;

    private void Start()
    {
        tmpText = GetComponent<TMP_Text>();
        LanguageManager.Instance.OnLanguageChanged += UpdateText;
        UpdateText();
    }

    private void OnDestroy()
    {
        LanguageManager.Instance.OnLanguageChanged -= UpdateText;
    }

    private void UpdateText()
    {
        if (LanguageManager.Instance.CurrentLanguage == LanguageManager.Language.English)
        {
            tmpText.text = englishText;
        }
        else if (LanguageManager.Instance.CurrentLanguage == LanguageManager.Language.Portuguese)
        {
            tmpText.text = portugueseText;
        }
    }
}

