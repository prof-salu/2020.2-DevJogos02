using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaAudio : MonoBehaviour
{
    //Singleton

    private AudioSource meuAudioSource;
    public static AudioSource Instancia;

    private void Awake()
    {
        meuAudioSource = GetComponent<AudioSource>();
        Instancia = meuAudioSource;
    }
}