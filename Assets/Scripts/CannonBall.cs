using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    public float destroyDelay = 10f; // Destroy cannonball after 5 seconds

    private void Start()
    {
        Destroy(gameObject, destroyDelay); // Auto-destroy cannonball
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacles"))
        {
            Destroy(collision.gameObject); // Destroy the obstacle
            Destroy(gameObject); // Destroy the cannonball on impact
        }
    }
}
