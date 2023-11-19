using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mundoController : MonoBehaviour
{
   
    public float velocidadRotacion = 50f;
    

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
        DestruirPlaneta();
        CambiarColorPelota(collision.gameObject);
       

        GameManager.singleton.AgregarPuntaje(5);

    }

    void CambiarColorPelota(GameObject pelota)
    {
        pelota.GetComponent<Renderer>().material.color = GetComponent<Renderer>().material.color;
    }

    void DestruirPlaneta()
    {
        Destroy(gameObject);
    }

    public void DestruirPlanets()
    {
        GameObject[] planets = GameObject.FindGameObjectsWithTag("planeta");
        foreach (GameObject planeta in planets)
        {
            Destroy(planeta);
        }
    }
}
