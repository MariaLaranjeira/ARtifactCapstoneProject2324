using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece_Move : MonoBehaviour
{
    private bool pieceSelected = false;
    public GameObject Menu;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Menu.activeSelf)
            return;
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

            switch(touch.phase)
            {
                case TouchPhase.Began:
                    Collider2D[] hitColliders = Physics2D.OverlapPointAll(touchPos);
                    System.Array.Sort(hitColliders, (a, b) => b.transform.position.z.CompareTo(a.transform.position.z));
                    if(hitColliders.Length > 0 && hitColliders[0].gameObject == gameObject)
                    {
                        pieceSelected = true;
                        transform.SetParent(rb.GetComponentInParent<Canvas>().transform);
                        transform.position = touchPos;
                    }else
                    {
                        pieceSelected = false;
                    }
                    break;
                case TouchPhase.Moved or TouchPhase.Stationary:
                    if(pieceSelected && touch.phase == TouchPhase.Moved && Input.touchCount == 1)
                    {
                        transform.position = touchPos;
                    }
                    if (Input.touchCount == 2)
                    {
                        Touch touchZero = Input.GetTouch(0);
                        Touch touchOne = Input.GetTouch(1);

                        // Calculate previous positions
                        Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
                        Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

                        // Find the angle between the touches in the previous frame
                        float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
                        float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

                        // Find the difference in the distances between each frame
                        float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

                        // Calculate angle between the touches
                        float angle = Mathf.Atan2(touchOne.position.y - touchZero.position.y, touchOne.position.x - touchZero.position.x) * Mathf.Rad2Deg;

                        // Calculate previous angle
                        float prevAngle = Mathf.Atan2(touchOnePrevPos.y - touchZeroPrevPos.y, touchOnePrevPos.x - touchZeroPrevPos.x) * Mathf.Rad2Deg;

                        // Find the difference in the angles
                        float angleDifference = angle - prevAngle;

                        // Rotate object
                        if (pieceSelected)
                        {
                            transform.Rotate(0, 0, -angleDifference);
                        }
                        // Scale object based on the distance change between touches
                        if (pieceSelected)
                        {
                            // Calculate the initial distance between the two touches
                            float initialTouchDistance = (touchZeroPrevPos - touchOnePrevPos).magnitude;

                            // Calculate the current distance between the two touches
                            float touchDistance = (touchZero.position - touchOne.position).magnitude;

                            // Calculate the scale factor based on the touch distance and initial touch distance
                            float scaleFactor = touchDistance / initialTouchDistance;

                            // Use deltaMagnitudeDiff to scale the object
                            float newScale = Mathf.Clamp(transform.localScale.x + (deltaMagnitudeDiff * scaleFactor), 0.5f, 2f);
                            transform.localScale = new Vector3(newScale, newScale, newScale);
                        }
                    }
                    break;
                case TouchPhase.Ended:
                    pieceSelected = false;
                    break;
            }
        }
    }
}
