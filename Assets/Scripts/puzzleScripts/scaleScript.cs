using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class scaleScript : MonoBehaviour
{
    private float initialDistance;
    private Vector3 initialScale;
    private Piece_Move piece_Move;
    //private Vector2 testPos;

    private void Start()
    {
        piece_Move = GetComponent<Piece_Move>();
    }

    private void Update()
    {
        if (Input.touchCount == 2 && piece_Move.pieceSelected)
        {
            //testPos = new Vector2(Screen.width / 2, Screen.height / 2);
            var touchZero = Input.GetTouch(0); 
            var touchOne = Input.GetTouch(1);

            if(touchZero.phase == TouchPhase.Ended || touchZero.phase == TouchPhase.Canceled 
            || touchOne.phase == TouchPhase.Ended || touchOne.phase == TouchPhase.Canceled)
            {
                return;
            }

            if(touchOne.phase == TouchPhase.Began)
            {
                initialDistance = Vector2.Distance(touchZero.position, touchOne.position);
                initialScale = transform.localScale;
            }
            else
            {
                var currentDistance = Vector2.Distance(touchZero.position, touchOne.position);

                if(Mathf.Approximately(initialDistance, 0)) return;

                var factor = currentDistance / initialDistance;

                transform.localScale = initialScale * factor;
            }
        }
    }
}
