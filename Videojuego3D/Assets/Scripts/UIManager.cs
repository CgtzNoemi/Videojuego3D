using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text PuntajeActualTexto;
    public Text MejorpuntajeTexto;


    void Update()
    {
        PuntajeActualTexto.text = "Puntaje: " + GameManager.singleton.PuntajeActual;
        MejorpuntajeTexto.text = "Mejor: " + GameManager.singleton.Mejorpuntaje;
    }
}
