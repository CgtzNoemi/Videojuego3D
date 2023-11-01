using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text PuntajeActualTexto;
    public Text MejorpuntajeTexto;

    public Slider slider;

    public TextMeshProUGUI actualLevel;
    public TextMeshProUGUI nextLevel;

    public Transform TopTransform;
    public Transform MetaTrasnform;

    public Transform pelota;




    void Update()
    {
        PuntajeActualTexto.text = "Puntos: " + GameManager.singleton.PuntajeActual;
        MejorpuntajeTexto.text = "Mejor: " + GameManager.singleton.Mejorpuntaje;

        ChangeSliderLevelAndProgress();
    }

    public void ChangeSliderLevelAndProgress()
    {
        actualLevel.text = "" + (GameManager.singleton.nivelActual + 1);

        nextLevel.text = "" + (GameManager.singleton.nivelActual + 2);

        float totalDistance = (TopTransform.position.y - MetaTrasnform.position.y);

        float distanceLeft = totalDistance - (pelota.position.y - MetaTrasnform.position.y);

        float value = (distanceLeft / totalDistance);

        slider.value = Mathf.Lerp(slider.value, value, 5);
    }
}
