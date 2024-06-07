using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextBoxScaler : MonoBehaviour
{
    public GameObject textBox;
    public float initialScale = 0.01f;
    public float targetScale = 1f;
    public float delayBeforeScaling = 5f; 
    public float scalingDuration = 0.5f;

    private Vector3 initialScaleVector;
    private Vector3 targetScaleVector;

    private void Start()
    {
        if (textBox != null)
        {
            initialScaleVector = new Vector3(initialScale, initialScale, initialScale);
            targetScaleVector = new Vector3(targetScale, targetScale, targetScale);
            textBox.transform.localScale = initialScaleVector;


            StartCoroutine(ScaleTextBox());
        }
        else
        {
            Debug.LogError("TextBoxScaler: Text box reference is not set.");
        }
    }

    private IEnumerator ScaleTextBox()
    {
        yield return new WaitForSeconds(delayBeforeScaling);

        float elapsedTime = 0f;

        while (elapsedTime < scalingDuration)
        {
            float progress = elapsedTime / scalingDuration;

            textBox.transform.localScale = Vector3.Lerp(initialScaleVector, targetScaleVector, progress);

            elapsedTime += Time.deltaTime;

            yield return null;
        }

        textBox.transform.localScale = targetScaleVector;
    }
}
