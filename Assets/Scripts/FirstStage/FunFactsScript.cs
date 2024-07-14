using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class FunFactsScript : MonoBehaviour, IPointerClickHandler
{
    public GameObject targetObject;
    public float animationDuration = 1f;
    public GameObject logo;
    public GameObject chispas;

    private Vector3 targetScale;
    private bool isAnimating = false;
    private bool isShowing = false;

    void Start()
    {

        if (targetObject != null)
        {
            targetScale = targetObject.transform.localScale;
            targetObject.transform.localScale = Vector3.zero;
        }
    }

    public void TriggerShowObject()
    {
        if (targetObject != null && !isAnimating)
        {
            targetObject.SetActive(true);
            StartCoroutine(ShowObjectCoroutine());
        }
    }

    private IEnumerator ShowObjectCoroutine()
    {
        isAnimating = true;
        float elapsedTime = 0f;
        Vector3 initialScale = targetObject.transform.localScale;

        while (elapsedTime < animationDuration)
        {
            targetObject.transform.localScale = Vector3.Lerp(initialScale, targetScale, elapsedTime / animationDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        targetObject.transform.localScale = targetScale;
        isAnimating = false;
        isShowing = true;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        logo.GetComponent<TriggerLogoRotationAtClick>().reset();
        logo.GetComponent<TriggerSpawnAtClick>().resetScale();
        logo.GetComponent<Button>().enabled = true;
        chispas.GetComponent<TriggerSpawnAtClick>().resetScale();
    }
}
