using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showShare : MonoBehaviour
{
    public GameObject sharePanel;
    public void showSharePanel()
    {
        sharePanel.transform.SetAsLastSibling();
        sharePanel.SetActive(true);
    }

    public void showPanelDelayed(){
        Invoke("showSharePanel", 0.5f);
    }
}
