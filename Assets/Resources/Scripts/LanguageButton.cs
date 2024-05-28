using UnityEngine;
using UnityEngine.UI;

public class LanguageButton : MonoBehaviour
{
    public LanguageManager.Language language;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(() => LanguageManager.Instance.SetLanguage(language));
    }
}
