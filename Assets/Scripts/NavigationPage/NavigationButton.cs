using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NavigationButton : MonoBehaviour
{

    public int levelIndex;
    public Image ButtonImage;
    public Image PaintStatusImage;
    public Sprite lockedPaint;
    public Sprite unlockedPaint;
    public Sprite normalButton;
    public Sprite selectedButton;
    private Button selfButton;


    // Start is called before the first frame update
    void Start()
    {
        selfButton = ButtonImage.GetComponent<Button>();
        UpdateButtonState();
    }

    void UpdateButtonState()
    {
        if (levelIndex == NavigationManager.CurrentLevel)
        {
            ButtonImage.sprite = selectedButton;
            ButtonImage.transform.localScale = new Vector3(2.1f, 2.1f, 2.1f); // Change button scale to 2.1

            PaintStatusImage.sprite = unlockedPaint;
            PaintStatusImage.transform.localScale = new Vector3(0.79f, 0.79f, 0.79f); // Change paint scale to 0.79
        }
        else if (NavigationManager.IsLevelUnlocked(levelIndex))
        {
            ButtonImage.sprite = normalButton;
            ButtonImage.transform.localScale = new Vector3(1.4f, 1.4f, 1.4f); // Change button scale to 1.4

            PaintStatusImage.sprite = unlockedPaint;
            PaintStatusImage.transform.localScale = new Vector3(0.85f, 0.85f, 0.85f); // Change paint scale to 0.85
        }
        else
        {
            ButtonImage.sprite = normalButton;
            ButtonImage.transform.localScale = new Vector3(1.4f, 1.4f, 1.4f); // Change button scale to 1.4

            PaintStatusImage.sprite = lockedPaint;

            if (levelIndex == 4) 
            {
                PaintStatusImage.transform.localScale = new Vector3(0.37f, 0.55f, 0.55f); // Change paint scale to 0.85
            } 
            else 
            {
                PaintStatusImage.transform.localScale = new Vector3(0.85f, 0.85f, 0.85f); // Change paint scale to 0.85
            }
        }
    }
}
