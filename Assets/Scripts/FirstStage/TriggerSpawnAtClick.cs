using System.Collections;
using UnityEngine;

public class TriggerSpawnAtClick : MonoBehaviour
{
    public GameObject textBox;
    public float initialScale = 0.01f;
    public float targetScale = 1f;
    public float delayBeforeScaling = 5f; 
    public float scalingDuration = 0.5f;

    private Vector3 initialScaleVector;
    private Vector3 targetScaleVector;
    private bool shouldStartScaling = false;

    void Start()
    {
        if (textBox != null)
        {
            initialScaleVector = new Vector3(initialScale, initialScale, initialScale);
            targetScaleVector = new Vector3(targetScale, targetScale, targetScale);
            textBox.transform.localScale = initialScaleVector;
        }
        else
        {
            Debug.LogError("TextBoxScaler: Text box reference is not set.");
        }
    }

    public void StartScale()
    {
        if (textBox != null)
        {
            shouldStartScaling = true;
            StartCoroutine(ScaleTextBox());
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

    public void resetScale()
    {
        textBox.transform.localScale = initialScaleVector;
        Debug.Log("Reset scale of textBox");
    }
}
