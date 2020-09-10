using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Personagem : MonoBehaviour
{
    public float velocidade = 5;

    private Animator animacao;

    
    void Start()
    {
        animacao = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Input.GetAxis("Horizontal"));
        //Debug.Log(Input.GetAxis("Vertical"));

        //Posicao ==> Vector3

        float movX = Input.GetAxis("Horizontal");
        float movZ = Input.GetAxis("Vertical");

        Vector3 direcao = new Vector3(movX, 0, movZ);

        transform.Translate(direcao * Time.deltaTime * velocidade);

        animacao.SetBool("Movendo", direcao != Vector3.zero);
    }
}
