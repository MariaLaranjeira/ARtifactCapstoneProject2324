using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showShare : MonoBehaviour
{
    public GameObject sharePanel;
    public GameObject shareButton;
    public void showSharePanel()
    {
        Canvas canvas = sharePanel.GetComponentInParent<Canvas>();
        foreach (Transform child in canvas.transform)
        {
            if(child.gameObject.name.StartsWith("Piece (")){
                child.gameObject.SetActive(false);
            }
        }
        //sharePanel.transform.SetAsLastSibling();
        shareButton.SetActive(false);
        sharePanel.SetActive(true);
    }

    public void showPanelDelayed(){
        Invoke("showSharePanel", 0.5f);
    }

    public void hideSharePanel()
    {
        sharePanel.SetActive(false);
    }
}
