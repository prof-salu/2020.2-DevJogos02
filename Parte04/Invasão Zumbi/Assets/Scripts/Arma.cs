using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma : MonoBehaviour
{
    public GameObject Bala;
    public GameObject PosicaoDaBala;

    void Update()
    {
        if (Input.GetButtonUp("Fire1"))
        {
            //Debug.Log("Atirando");
            //Instantiate(gameobject, posicao, rotacao);
            Instantiate(Bala, PosicaoDaBala.transform.position, PosicaoDaBala.transform.rotation);
        }
    }
}
