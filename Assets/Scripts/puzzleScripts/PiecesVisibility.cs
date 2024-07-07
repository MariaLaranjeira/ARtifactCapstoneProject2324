using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiecesVisibility : MonoBehaviour
{
    // Start is called before the first frame update
    public void make_pieces_invisible()
    {
        Canvas canvas = gameObject.GetComponentInParent<Canvas>();
        foreach (Transform child in canvas.transform)
        {
            if(child.gameObject.name.StartsWith("Piece (")){
                child.gameObject.SetActive(false);
            }
        }
    }

    public void make_pieces_visible()
    {
        Canvas canvas = gameObject.GetComponentInParent<Canvas>();
        foreach (Transform child in canvas.transform)
        {
            if(child.gameObject.name.StartsWith("Piece (")){
                child.gameObject.SetActive(true);
            }
        }
    }
}
