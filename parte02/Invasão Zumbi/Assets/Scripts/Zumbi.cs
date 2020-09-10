using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zumbi : MonoBehaviour
{
    public GameObject Jogador;
    public float velocidade = 5;
    public float distanciaAtaque = 1.5f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float distanciaParaJogador = Vector3.Distance(transform.position, Jogador.transform.position);
        
        if(distanciaParaJogador > distanciaAtaque)
        {
            Vector3 direcao = Jogador.transform.position - transform.position;
            rb.MovePosition(rb.position + (direcao.normalized * velocidade * Time.deltaTime));

            Quaternion novaRotacao = Quaternion.LookRotation(direcao);
            rb.MoveRotation(novaRotacao);
        }        
    }
}
