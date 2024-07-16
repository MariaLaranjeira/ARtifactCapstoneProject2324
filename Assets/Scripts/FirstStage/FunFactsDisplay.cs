using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class FunFactsDisplay : MonoBehaviour
{
    public TextMeshProUGUI funFactTextBox; // The TextMeshPro text box to display the fun fact
    public Button displayFunFactButton; // The button that will trigger the display of a fun fact
    public string[] englishFunFacts; // Array of fun facts in English
    public string[] portugueseFunFacts; // Array of fun facts in Portuguese

    void Start()
    {
        if (funFactTextBox == null)
        {
            Debug.LogError("FunFactsDisplay: Text box reference is not set.");
        }

        if (displayFunFactButton == null)
        {
            Debug.LogError("FunFactsDisplay: Button reference is not set.");
        }
        else
        {
            displayFunFactButton.onClick.AddListener(DisplayRandomFunFact);
        }
    }

    public void DisplayRandomFunFact()
    {
        string[] selectedFunFacts;

        // Determine which list of fun facts to use based on the current language
        if (LanguageManager.Instance.CurrentLanguage == LanguageManager.Language.English)
        {
            selectedFunFacts = englishFunFacts;
        }
        else
        {
            selectedFunFacts = portugueseFunFacts;
        }

        // Display a random fun fact from the selected list
        if (selectedFunFacts.Length > 0)
        {
            int randomIndex = Random.Range(0, selectedFunFacts.Length);
            funFactTextBox.text = selectedFunFacts[randomIndex];
        }
        else
        {
            Debug.LogWarning("FunFactsDisplay: No fun facts available to display.");
        }
    }
}
