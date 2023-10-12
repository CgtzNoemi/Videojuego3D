using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraController : MonoBehaviour
{
    public PelotaController pelota;

    private float offset;

    void Start()
    {
        offset = transform.position.y - pelota.transform.position.y;
    }

    void Update()
    {
        Vector3 posicionActual = transform.position;
        posicionActual.y = pelota.transform.position.y + offset;
        transform.position = posicionActual;
    }
}
