using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class UIManager : MonoBehaviour
{

    public GameObject customizationPanel;

    // Arrays to hold the sprites for different body parts
    public Sprite[] headSprites;
    public Sprite[] bodySprites;
    public Sprite[] legsSprites;

    // Image UI components to display the body part sprites
    public Image headImage;
    public Image bodyImage;
    public Image legsImage;

    private string saveFilePath;

    // Indices to keep track of the current sprite selection
    private int currentHeadIndex;
    private int currentBodyIndex;
    private int currentLegsIndex;
    

        private void Awake()
    {
        saveFilePath = Path.Combine(Application.persistentDataPath, "characterCustomization.txt");
    }

    // Start is called before the first frame update
    void Start()
    {
       LoadCharacterCustomization();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleCustomizationPanel()
    {
        customizationPanel.SetActive(!customizationPanel.activeSelf);
    }

    public void NextHead()
    {
        // Increment the index, wrap it if necessary
        currentHeadIndex = (currentHeadIndex + 1) % headSprites.Length;
        // Update the head sprite
        headImage.sprite = headSprites[currentHeadIndex];
    }

    public void NextBody() 
    {
        // Increment the index, wrap it if necessary
        currentBodyIndex = (currentBodyIndex + 1) % bodySprites.Length;
        // Update the body sprite
        bodyImage.sprite = bodySprites[currentBodyIndex];
    }

    public void NextLegs() 
    {
        // Increment the index, wrap it if necessary
        currentLegsIndex = (currentLegsIndex + 1) % legsSprites.Length;
        // Update the legs sprite
        legsImage.sprite = legsSprites[currentLegsIndex];
    }

    // Call this method when the "previous" button for the head is pressed
    public void PreviousHead()
    {
        Debug.Log("Previous button pressed. Current index before decrement: " + currentHeadIndex);
        // Decrement the index, wrap it if necessary
        currentHeadIndex--;
        if (currentHeadIndex < 0)
        {
            currentHeadIndex = headSprites.Length - 1;
        }
        // Update the head sprite
        headImage.sprite = headSprites[currentHeadIndex];
    }

    public void PreviousBody()
    {
        // Decrement the index, wrap it if necessary
        currentBodyIndex--;
        if (currentBodyIndex < 0)
        {
            currentBodyIndex = bodySprites.Length - 1;
        }
        // Update the body sprite
        bodyImage.sprite = bodySprites[currentBodyIndex];
    }

    public void PreviousLegs()
    {
        // Decrement the index, wrap it if necessary
        currentLegsIndex--;
        if (currentLegsIndex < 0)
        {
            currentLegsIndex = legsSprites.Length - 1;
        }
        // Update the legs sprite
        legsImage.sprite = legsSprites[currentLegsIndex];
    }

    public void SaveCharacterCustomization()
    {
        // Construct a string to save, for example, with index values of the current selections
        string toSave = currentHeadIndex.ToString() + "\n" + currentBodyIndex.ToString() + "\n" + currentLegsIndex.ToString();
        File.WriteAllText(saveFilePath, toSave);
        Debug.Log("Customization saved to: " + saveFilePath);
    }

    public void LoadCharacterCustomization()
    {
        // Check if the save file exists
        if (File.Exists(saveFilePath))
        {
            // Read the contents of the save file
            string[] savedData = File.ReadAllLines(saveFilePath);
        
            // Ensure we have at least three lines, one for each body part
            if (savedData.Length >= 3)
            {
                // Parse the saved data to your customization settings
                int savedHeadIndex = int.Parse(savedData[0]);
                int savedBodyIndex = int.Parse(savedData[1]);
                int savedLegsIndex = int.Parse(savedData[2]);
                
                // Now apply these settings to the UI
                currentHeadIndex = Mathf.Clamp(savedHeadIndex, 0, headSprites.Length - 1);
                headImage.sprite = headSprites[currentHeadIndex];

                currentBodyIndex = Mathf.Clamp(savedBodyIndex, 0, bodySprites.Length - 1);
                bodyImage.sprite = bodySprites[currentBodyIndex];

                currentLegsIndex = Mathf.Clamp(savedLegsIndex, 0, legsSprites.Length - 1);
                legsImage.sprite = legsSprites[currentLegsIndex];
            }
        }
        else {
            // Initialize the images with the first sprite of the arrays
            if (headSprites.Length > 0)
            {
                headImage.sprite = headSprites[0];
                currentHeadIndex = 0;
            }

            if (bodySprites.Length > 0)
            {
                bodyImage.sprite = bodySprites[0];
                currentBodyIndex = 0;
            }

            if (legsSprites.Length > 0)
            {
                legsImage.sprite = legsSprites[0];
                currentLegsIndex = 0;
            }

        }
    }

}
