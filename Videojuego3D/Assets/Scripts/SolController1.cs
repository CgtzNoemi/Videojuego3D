using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SolController1 : MonoBehaviour
{

    public float velocidadRotacion = -50f;

    void Update()
    {
        TuboController tuboController = FindObjectOfType<TuboController>();
        Transform tuboTransform = tuboController.tuboTransform;
        Vector3 ejeRotacion = tuboTransform.up;

        transform.RotateAround(tuboTransform.position, ejeRotacion, velocidadRotacion * Time.deltaTime);
        transform.LookAt(tuboTransform.position);
    }
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Impacto esfera");
        DestruirSol();

        GameManager.singleton.QuitarPuntaje(5);


    }



    void DestruirSol()
    {
        Destroy(gameObject);
    }

    public void DestruirSoles()
    {
        GameObject[] soles = GameObject.FindGameObjectsWithTag("sol");
        foreach (GameObject sol in soles)
        {
            Destroy(sol);
        }
    }
}
