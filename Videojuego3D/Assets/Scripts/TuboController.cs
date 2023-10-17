using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TuboController : MonoBehaviour
{
    private Vector2 UltimoPosicion;
    private Vector3 PosicionInicial;


    void Start()
    {
       PosicionInicial = transform.localEulerAngles;
    }

    
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            Vector2 PosicionActual = Input.mousePosition;

            if(UltimoPosicion == Vector2.zero)
            {
                UltimoPosicion = PosicionActual;
            }

            float distancia = UltimoPosicion.x - PosicionActual.x;
            UltimoPosicion = PosicionActual;

            transform.Rotate(Vector3.up * distancia);
        }

        if(Input.GetMouseButtonUp(0))
        {
            UltimoPosicion = Vector2.zero;
        }
    }
}
