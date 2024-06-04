using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageManager : MonoBehaviour
{
    public static LanguageManager Instance { get; private set; } // Singleton, can only be set by this class

    public enum Language
    {
        English,
        Portuguese
    }

    public Language CurrentLanguage { get; private set; } = Language.Portuguese; // Default language, can only be set by this class

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetLanguage(Language language)
    {
        CurrentLanguage = language;
        OnLanguageChanged?.Invoke(); // Notifies the subscribers that the language has changed
    }

    public delegate void LanguageChanged();
    public event LanguageChanged OnLanguageChanged;
}
