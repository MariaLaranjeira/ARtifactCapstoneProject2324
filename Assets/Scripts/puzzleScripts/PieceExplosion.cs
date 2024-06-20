using UnityEngine;

public class PieceExplosion : MonoBehaviour
{
    public float explosionForce = 500f;
    public Vector2 explosionCenter;
    Rigidbody2D rb;
    public float delay = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        explosionCenter = rb.GetComponentInParent<Canvas>().transform.position;
        Invoke("Explode", delay);
    }

    public void Explode()
    {
        // Assuming this script is attached to the GameObject you want to explode

        if (rb != null)
        {
            // Calculate direction from the explosion center to the piece
            Vector2 explosionDirection = (rb.position - explosionCenter).normalized;

            // Apply force in the direction away from the explosion center
            rb.AddForce(explosionDirection * explosionForce);
        }
    }
}