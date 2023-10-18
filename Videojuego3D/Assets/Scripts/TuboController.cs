using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TuboController : MonoBehaviour
{
    private Vector2 UltimoPosicion;
    private Vector3 PosicionInicial;
    public Transform topTransform;
    public Transform goalTransform;
    public GameObject TuboLevelPrefab;
    public List<Stage> allStages = new List<Stage>();
    public float TuboDistancia;
    private List<GameObject> spawnedLevels = new List<GameObject>();

    
    private void Awake() 
    {
        PosicionInicial = transform.localEulerAngles;
        TuboDistancia = topTransform.localPosition.y - (goalTransform.localPosition.y + 0.1f);
        //LoadStage(0);
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

    public void LoadStage(int stageNumber)
    {

    }
}
