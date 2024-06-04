using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    private TMP_Text dialogueText;
    private Queue<string> dialogueLines;
    private LanguageManager.Language currentLanguage;

    public List<string> englishLines;
    public List<string> portugueseLines;
    public string nextSceneName;

    void Awake()
    {
        dialogueText = GetComponentInChildren<TMP_Text>();
        if (dialogueText == null)
        {
            Debug.LogError("No TMP_Text component found in children.");
        }

        dialogueLines = new Queue<string>();

        if (LanguageManager.Instance != null)
        {
            currentLanguage = LanguageManager.Instance.CurrentLanguage;
            LanguageManager.Instance.OnLanguageChanged += OnLanguageChanged;
        }
        else
        {
            Debug.LogError("LanguageManager instance not found.");
        }
    }

    void Start()
    {
        StartDialogue();
    }

    void OnDestroy()
    {
        if (LanguageManager.Instance != null)
        {
            LanguageManager.Instance.OnLanguageChanged -= OnLanguageChanged;
        }
    }

    void OnLanguageChanged()
    {
        currentLanguage = LanguageManager.Instance.CurrentLanguage;
        StartDialogue();
    }

    public void StartDialogue()
    {
        dialogueLines.Clear();

        if (currentLanguage == LanguageManager.Language.English)
        {
            foreach (string line in englishLines)
            {
                dialogueLines.Enqueue(line);
            }
        }
        else if (currentLanguage == LanguageManager.Language.Portuguese)
        {
            foreach (string line in portugueseLines)
            {
                dialogueLines.Enqueue(line);
            }
        }

        DisplayNextLine();
    }

    public void DisplayNextLine()
    {
        if (dialogueLines.Count == 0)
        {
            EndDialogue();
            return;
        }

        string line = dialogueLines.Dequeue();
        dialogueText.text = line;
    }

    void EndDialogue()
    {
        Debug.Log("End of dialogue.");
        if (!string.IsNullOrEmpty(nextSceneName))
        {
            SceneHistoryManager.LoadScene(nextSceneName);
        }
    }
}
