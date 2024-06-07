using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSceneryBackground : MonoBehaviour
{
    public GameObject Scenery;

    public Color hexConverter(string hex)
    {
        float r = int.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber) / 255f;
        float g = int.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber) / 255f;
        float b = int.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber) / 255f;

        return new Color(r, g, b);
    }

    public void Button1()
    {
        Color color = hexConverter("12383D");
        Scenery.GetComponent<Image>().color = color;
    }

    public void Button2()
    {
        Color color = hexConverter("0A1012");
        Scenery.GetComponent<Image>().color = color;
    }

    public void Button3()
    {
        Color color = hexConverter("8B9BB1");
        Scenery.GetComponent<Image>().color = color;
    }

    public void Button4()
    {
        Color color = hexConverter("E8F0F2");
        Scenery.GetComponent<Image>().color = color;
    }

}
