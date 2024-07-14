using System.Collections;
using UnityEngine;

public class TriggerLogoRotationAtClick : MonoBehaviour
{
    public float rotationSpeedDegSec = 180f;
    public float rotationIntervalSec = 2f;
    public float scaleMultiplier = 1.1f;
    public float timeToRotate = 0f;
    public float acceleration = 0f;

    private float timeSinceLastRotation;
    private Vector3 originalScale;
    private bool isRotating;
    private bool rotationCompleted = false;
    private bool shouldStartRotation = false;

    private void Start()
    {
        originalScale = transform.localScale;
    }

    public void StartRotation()
    {
        shouldStartRotation = true;
    }

    private void Update()
    {
        if (rotationCompleted || !shouldStartRotation)
        {
            return;
        }

        if (timeToRotate > 0f)
        {
            if (!isRotating)
            {
                StartCoroutine(RotateForTime(timeToRotate));
            }
        }
        else
        {
            timeSinceLastRotation += Time.deltaTime;

            if (timeSinceLastRotation >= rotationIntervalSec)
            {
                timeSinceLastRotation = 0f;
                StartCoroutine(RotateAndScale());
            }
        }
    }

    private IEnumerator RotateForTime(float duration)
    {
        isRotating = true;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            float rotationStep = rotationSpeedDegSec * Time.deltaTime;
            transform.Rotate(Vector3.forward, rotationStep);

            elapsedTime += Time.deltaTime;

            if (acceleration > 0f)
            {
                rotationSpeedDegSec += acceleration * Time.deltaTime;
            }

            yield return null;
        }

        isRotating = false;
        rotationCompleted = true;
    }

    private IEnumerator RotateAndScale()
    {
        isRotating = true;
        float totalRotation = 0f;
        float halfRotation = 180f;
        float duration = halfRotation / rotationSpeedDegSec;

        float timeElapsed = 0f;

        while (totalRotation < halfRotation)
        {
            float rotationStep = rotationSpeedDegSec * Time.deltaTime;
            totalRotation += rotationStep;

            timeElapsed += Time.deltaTime;
            float progress = timeElapsed / duration;
            float scale_x = Mathf.Lerp(originalScale.x, originalScale.x * scaleMultiplier, Mathf.Sin(progress * Mathf.PI));
            float scale_y = Mathf.Lerp(originalScale.y, originalScale.y * scaleMultiplier, Mathf.Sin(progress * Mathf.PI));

            transform.Rotate(Vector3.forward, rotationStep);
            transform.localScale = new Vector3(scale_x, scale_y, transform.localScale.z);

            // Apply acceleration if specified
            if (acceleration > 0f)
            {
                rotationSpeedDegSec += acceleration * Time.deltaTime;
            }

            yield return null;
        }

        isRotating = false;
    }

    public void reset ()
    {
        rotationCompleted = false;
        shouldStartRotation = false;
        transform.localScale = originalScale;
        transform.rotation = Quaternion.identity;
    }
}
