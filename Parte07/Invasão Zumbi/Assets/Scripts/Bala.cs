using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public float Velocidade = 30;

    public AudioClip SomDeMorte;
    public GameObject ParticulaSangueZumbi;

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
            //Destroy(other.gameObject);
            ControlaAudio.Instancia.PlayOneShot(SomDeMorte);

            SangueDoZumbi(transform.position, other.gameObject.transform.rotation);
        }
        
        Destroy(gameObject);
    }

    private void SangueDoZumbi(Vector3 posicao, Quaternion rotacao)
    {
        Instantiate(ParticulaSangueZumbi, posicao, rotacao);
    }
}
