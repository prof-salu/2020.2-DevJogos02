using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Personagem : MonoBehaviour
{
    public float velocidade = 5;
    private Vector3 direcao;

    private Animator animacao;
    private Rigidbody rb;

    
    void Start()
    {
        animacao = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Input.GetAxis("Horizontal"));
        //Debug.Log(Input.GetAxis("Vertical"));

        //Posicao ==> Vector3

        float movX = Input.GetAxis("Horizontal");
        float movZ = Input.GetAxis("Vertical");

        direcao = new Vector3(movX, 0, movZ);

        //transform.Translate(direcao * Time.deltaTime * velocidade);

        
        animacao.SetBool("Movendo", direcao != Vector3.zero);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + (direcao * Time.deltaTime * velocidade));
    }
}
