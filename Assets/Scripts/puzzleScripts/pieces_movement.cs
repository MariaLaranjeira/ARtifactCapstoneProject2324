using System.Linq;
using UnityEngine;

public class pieces_movement : MonoBehaviour
{
    private Vector3 offset;
    private float zCoordinate;
    private float rotationRate = 200f;

    private bool touch;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            RaycastHit2D[] hits = Physics2D.RaycastAll(touchPosition, Vector2.zero);
            RaycastHit2D hit = new RaycastHit2D();
            hits = hits.OrderBy(h => h.transform.position.z).ToArray();
            hit = hits.Length > 0 ? hits[0] : new RaycastHit2D();

            if (Input.touchCount == 1)
            {
                if (touch.phase == TouchPhase.Began && hit.transform != null && hit.transform.gameObject == gameObject)
                {
                    transform.SetParent(transform.GetComponentInParent<Canvas>().transform);
                    zCoordinate = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
                    offset = gameObject.transform.position - GetTouchWorldPos(touch);
                }
                else if (touch.phase == TouchPhase.Moved && hit.transform != null && hit.transform.gameObject == gameObject)
                {
                    transform.position = GetTouchWorldPos(touch) + offset;
                }
            }
            else if (Input.touchCount == 2 && hit.transform != null && hit.transform.gameObject == gameObject)
            {
                Touch touchZero = Input.GetTouch(0);
                Touch touchOne = Input.GetTouch(1);

                Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
                Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

                float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
                float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

                float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

                transform.Rotate(new Vector3(0, 0, deltaMagnitudeDiff * rotationRate * Time.deltaTime));
                float scaleFactor = 0.01f;
                float currentScale = transform.localScale.x;

                if (deltaMagnitudeDiff > 0)
                {
                    currentScale += scaleFactor;
                }
                else if (deltaMagnitudeDiff < 0)
                {
                    currentScale -= scaleFactor;
                }

                currentScale = Mathf.Clamp(currentScale, 0.5f, 2f);
                transform.localScale = new Vector3(currentScale, currentScale, currentScale);
            }
        }
    }

    private Vector3 GetTouchWorldPos(Touch touch)
    {
        return Camera.main.ScreenToWorldPoint(touch.position);
    }
}
