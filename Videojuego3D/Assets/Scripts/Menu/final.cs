using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class final : MonoBehaviour
{
    public TextMeshProUGUI PuntajeActualTexto;
    public TextMeshProUGUI MejorpuntajeTexto;
    public Text NuevoRecord;
    void Update()
    {
        int puntajeActual = GameManager.singleton.PuntajeActual;
        int MejorPuntaje = GameManager.singleton.Mejorpuntaje;
        PuntajeActualTexto.text = "Lograste " + puntajeActual+ " puntos";
        MejorpuntajeTexto.text = "Mejor puntaje: " + MejorPuntaje;
        if(puntajeActual == MejorPuntaje)
        {
            NuevoRecord.GetComponent<Animation>().Play();
        }

    }
    public void EmpezarElJuego()
    {
        SceneManager.LoadScene("Nivel");
    }
    public void SalirDelJuego()
    {
        Application.Quit();
        Debug.Log("Salir del juego");
    }
}
