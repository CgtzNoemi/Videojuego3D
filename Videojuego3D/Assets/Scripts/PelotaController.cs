using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PelotaController : MonoBehaviour
{
    public Rigidbody fisicas;
    public float fuerzaImpulso = 3f;

    private bool ignorarNextCollision;

    private void OnCollisionEnter(Collision collision)
    {
        if(ignorarNextCollision)
        {
            return;
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
}
