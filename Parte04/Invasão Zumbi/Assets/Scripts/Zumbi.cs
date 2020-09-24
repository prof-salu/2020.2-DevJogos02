using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Zumbi : MonoBehaviour
{
    private GameObject Jogador;
    public float velocidade = 5;
    public float distanciaAtaque = 1.5f;

    private Rigidbody rb;
    private Animator animacao;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animacao = GetComponent<Animator>();
    }

    private void Start()
    {
        Jogador = GameObject.FindWithTag("Personagem");
    }

    private void FixedUpdate()
    {
        //Calculando a direcao do jogador
        float distanciaParaJogador = Vector3.Distance(transform.position, Jogador.transform.position);
        

        if (distanciaParaJogador > distanciaAtaque)
        {
            Vector3 direcao = Jogador.transform.position - transform.position;
            rb.MovePosition(rb.position + (direcao.normalized * velocidade * Time.deltaTime));
            
            Quaternion novaRotacao = Quaternion.LookRotation(direcao);
            rb.MoveRotation(novaRotacao);

            animacao.SetBool("Atacando", false);
        }
        else
        {
            animacao.SetBool("Atacando", true);
        }        
    }

    private void AtacaJogador()
    {
        //Debug.Log("Acertou o jogador...");
        Time.timeScale = 0;
        Jogador.GetComponent<Personagem>().TextoGameOver.SetActive(true);
        Jogador.GetComponent<Personagem>().EstaVivo = false;
    }
}
