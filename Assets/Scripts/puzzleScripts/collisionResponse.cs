using System.Collections;
using UnityEngine;

public class collisionResponse : MonoBehaviour
{
    public float forceMagnitude = 10f; // Adjust this value to change the force applied

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision detected");
    }

    void Start()
    {
        StartCoroutine(DisappearAfterDelay(15f));
    }

    IEnumerator DisappearAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        gameObject.SetActive(false);
    }
}