using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Personagem : MonoBehaviour
{
    public float velocidade = 5;
    public LayerMask MascaraDoChao;
    //Precisa fazer o import do UI
    public GameObject TextoGameOver;

    public bool EstaVivo;

    private Vector3 direcao;
    private Animator animacao;
    private Rigidbody rb;

    private void Awake()
    {
        animacao = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        EstaVivo = true;
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

        if(EstaVivo == false)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                ReiniciarPartida();
            }
        }
    }

    private void FixedUpdate()
    {
        // Movimentacao do Personagem
        rb.MovePosition(rb.position + (direcao * Time.deltaTime * velocidade));

        Ray raio = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(raio.origin, raio.direction * 100, Color.red);

        RaycastHit impacto;

        if(Physics.Raycast(raio, out impacto, 100, MascaraDoChao))
        {
            Vector3 posicaoMiraJogador = impacto.point - transform.position;

            Quaternion novaRotacao = Quaternion.LookRotation(posicaoMiraJogador);

            rb.MoveRotation(novaRotacao);
        }

    }

    private void ReiniciarPartida()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Fase01");
    }
}
