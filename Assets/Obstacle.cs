using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class Obstacle : MonoBehaviour
{
    void Awake()
    {
        // Ensure the GameObject has a Rigidbody component
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.isKinematic = true; 

        // Ensure the GameObject has a Collider component
        Collider collider = gameObject.GetComponent<Collider>();
        if (collider == null)
        {
            // If no collider is found, add a BoxCollider by default
            BoxCollider boxCollider = gameObject.AddComponent<BoxCollider>();
            boxCollider.size = new Vector3(1, 1, 1); 
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Optional: Handle collision events if needed
        Debug.Log("Collision with: " + collision.gameObject.name);
    }

    void Start()
    {
      
    }
}
