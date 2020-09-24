using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public float Velocidade = 30;

    private Rigidbody rb;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + (transform.forward * Velocidade * Time.deltaTime));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Inimigo")){
            Destroy(other.gameObject);
        }
        
        Destroy(gameObject);
    }
}
