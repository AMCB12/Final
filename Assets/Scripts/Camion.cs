using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camion : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 200f;
    private BoxCollider collision;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        collision = rb.GetComponent<BoxCollider>();
        
    }

    private void FixedUpdate()
    {

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Collision detected with: " + collision.gameObject.name);
        }

        float moveInput = Input.GetAxis("Vertical");
        float rotationInput = Input.GetAxis("Horizontal");

        // Movimiento del carro hacia adelante y atrás
        Vector3 movement = transform.forward * moveInput * moveSpeed * Time.deltaTime;
        rb.MovePosition(rb.position + movement);

        // Rotación del carro
        Quaternion rotation = Quaternion.Euler(0f, rotationInput * rotationSpeed * Time.deltaTime, 0f);
        rb.MoveRotation(rb.rotation * rotation);
       



    }
    
        private void OnCollisionEnter(Collision collision)
        {
            Debug.Log("Collision detected with: " + collision.gameObject.name);
        }
   
}
