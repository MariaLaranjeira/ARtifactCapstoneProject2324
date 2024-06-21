using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showShare : MonoBehaviour
{
    public GameObject sharePanel;
    public GameObject threedots;
    public void showSharePanel()
    {
        sharePanel.transform.SetAsLastSibling();
        threedots.transform.SetAsLastSibling();
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
