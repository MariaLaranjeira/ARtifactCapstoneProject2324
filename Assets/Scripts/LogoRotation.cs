using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoRotation : MonoBehaviour
{
    public float rotationSpeedDegSec = 180f;
    public float rotationIntervalSec = 2f;
    public float scaleMultiplier = 1.1f;
    private float timeSinceLastRotation;
    private Vector3 originalScale;

    private void Start()
    {
        originalScale = transform.localScale;
    }

    private void Update()
    {
        timeSinceLastRotation += Time.deltaTime;

        if (timeSinceLastRotation >= rotationIntervalSec)
        {
            timeSinceLastRotation = 0f;
            StartCoroutine(RotateAndScale());
        }
    }

    private IEnumerator RotateAndScale()
    {
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
            yield return null;
        }

        //transform.localScale = originalScale;
    }
}
