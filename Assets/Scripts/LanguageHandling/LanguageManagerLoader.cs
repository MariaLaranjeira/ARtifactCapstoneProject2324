using UnityEngine;

public class LanguageManagerLoader : MonoBehaviour
{
    public GameObject languageManagerPrefab;

    void Awake()
    {
        if (LanguageManager.Instance == null)
        {
            Instantiate(languageManagerPrefab);
        }
    }
}
