using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int Mejorpuntaje;
    public int PuntajeActual;

    public int nivelActual = 0;
    public Text AgregarPuntos;

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

        nivelActual++;
        if (nivelActual==5)
        {
            SceneManager.LoadScene("final");
        }
        else
        {
            FindObjectOfType<PelotaController>().ResetBall();
            FindAnyObjectByType<SolController1>().DestruirSoles();
            FindAnyObjectByType<mundoController>().DestruirPlanets();
            FindObjectOfType<TuboController>().LoadStage(nivelActual);
            Debug.Log("Pasamos de nivel");
        }

    }

    public void ReiniciarNivel()
    {
        Debug.Log("Restart");
        singleton.PuntajeActual = 0;
        FindObjectOfType<PelotaController>().ResetBall();
        FindAnyObjectByType<SolController1>().DestruirSoles();
        FindAnyObjectByType<mundoController>().DestruirPlanets();
        FindObjectOfType<TuboController>().LoadStage(nivelActual);
        
    }

    public void AgregarPuntaje(int puntajeaAgregar)
    {
        AgregarPuntos.text = "+" + puntajeaAgregar;
        AgregarPuntos.GetComponent<Animation>().Play();
        PuntajeActual += puntajeaAgregar;

        if(PuntajeActual > Mejorpuntaje)
        {
            Mejorpuntaje = PuntajeActual;
            PlayerPrefs.SetInt("MejorPuntaje", PuntajeActual);
        }
    }

    public void QuitarPuntaje(int puntajeaQuitar)
    {
        AgregarPuntos.text = "-" + puntajeaQuitar;
        AgregarPuntos.GetComponent<Animation>().Play();
        PuntajeActual -= puntajeaQuitar;

    }




}
