using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlaInterface : MonoBehaviour
{
    public Slider BarraDeVida;
    public GameObject Jogador;
    
    void Start()
    {
        BarraDeVida.maxValue = Jogador.GetComponent<Personagem>().Vida;
    }

   public void AtualizaBarraDeVida()
    {
        BarraDeVida.value = Jogador.GetComponent<Personagem>().Vida;
    }
}
