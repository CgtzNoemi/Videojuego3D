using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int Mejorpuntaje;
    public int PuntajeActual;

    public int nivelActual = 0;

    public static GameManager singleton;

    void Awake() 
    {
        if(singleton == null)
        {
            singleton = this;
        }
        else if(singleton = this)
        {
            Destroy(gameObject);
        }
        Mejorpuntaje = PlayerPrefs.GetInt("MejorPuntaje");
    }

    public void SiguienteNivel()
    {
        Debug.Log("Pasamos de nivel");
    }

    public void ReiniciarNivel()
    {
        Debug.Log("Restart");
        singleton.PuntajeActual = 0;
        FindObjectOfType<PelotaController>().ResetBall();
    }

    public void AgregarPuntaje(int puntajeaAgregar)
    {
        PuntajeActual += puntajeaAgregar;

        if(PuntajeActual > Mejorpuntaje)
        {
            Mejorpuntaje = PuntajeActual;
            PlayerPrefs.SetInt("MejorPuntaje", PuntajeActual);
        }
    }

}
