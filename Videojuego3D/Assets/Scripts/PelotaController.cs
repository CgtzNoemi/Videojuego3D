using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PelotaController : MonoBehaviour
{
    public Rigidbody fisicas;
    public float fuerzaImpulso = 3f;

    private bool ignorarNextCollision;

    private Vector3 PosicionInicial;

    [HideInInspector]
    public int perfectPass;

    public float superSpeed = 8;

    private bool isSuperSpeedActive;

    public int perfectPassCount = 1;

    private void Start()
    {
        PosicionInicial = transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (ignorarNextCollision)
        {
            return;
        }

        if (isSuperSpeedActive && !collision.transform.GetComponent<GoalController>())
        {
            Destroy(collision.transform.parent.gameObject, 0.2f);
        }
        else
        {
            DeathPart deathPart = collision.transform.GetComponent<DeathPart>();
            if (deathPart)
            {
                GameManager.singleton.ReiniciarNivel();
            }
        }


        fisicas.velocity = Vector3.zero;
        fisicas.AddForce(Vector3.up * fuerzaImpulso, ForceMode.Impulse);

        ignorarNextCollision = true;
        Invoke("AllowNextCollision", 0.2f);

        perfectPass = 0;
        isSuperSpeedActive = false;
    }

    private void Update()
    {
        if (perfectPass >= perfectPassCount && !isSuperSpeedActive)
        {
            isSuperSpeedActive=true;

            fisicas.AddForce(Vector3.down * superSpeed, ForceMode.Impulse);
        }
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
