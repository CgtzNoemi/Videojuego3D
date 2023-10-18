using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PelotaController : MonoBehaviour
{
    public Rigidbody fisicas;
    public float fuerzaImpulso = 3f;

    private bool ignorarNextCollision;

    private Vector3 PosicionInicial;

    private void Start() 
    {
        PosicionInicial = transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if(ignorarNextCollision)
        {
            return;
        }

        DeathPart deathPart = collision.transform.GetComponent<DeathPart>();
        if(deathPart)
        {
            GameManager.singleton.ReiniciarNivel();
        }

        fisicas.velocity = Vector3.zero;
        fisicas.AddForce(Vector3.up*fuerzaImpulso, ForceMode.Impulse);

        ignorarNextCollision = true;
        Invoke("AllowNextCollision",0.2f);
    }

    private void AllowNextCollision()
    {
        ignorarNextCollision = false;
    }

    public void ResetBall()
    {
        transform.position = PosicionInicial;
    }
}
