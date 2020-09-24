using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorDeZumbis : MonoBehaviour
{
    public GameObject Zumbi;

    public float intervaloDeCriacao = 1;
    private float timerZumbi = 0;
    
    void Update()
    {
        timerZumbi -= Time.deltaTime;

        if(timerZumbi <= 0)
        {
            Instantiate(Zumbi, transform.position, transform.rotation);
            timerZumbi = intervaloDeCriacao;
        }        
    }
}
