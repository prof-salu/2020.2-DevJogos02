using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaCamera : MonoBehaviour
{
    public GameObject Jogador;

    private Vector3 distanciaParaJogador;
    void Start()
    {
        distanciaParaJogador = transform.position - Jogador.transform.position;
    }

    
    void Update()
    {
        transform.position = Jogador.transform.position + distanciaParaJogador;
    }
}
