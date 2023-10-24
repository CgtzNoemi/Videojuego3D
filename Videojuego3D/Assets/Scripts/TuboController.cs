using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TuboController : MonoBehaviour
{
    private Vector2 UltimoPosicion;
    private Vector3 RotacionInicial;
    public Transform topTransform;
    public Transform goalTransform;
    public GameObject TuboLevelPrefab;
    public List<Stage> allStages = new List<Stage>();
    public float TuboDistancia;
    private List<GameObject> spawnedLevels = new List<GameObject>();

    
    private void Awake() 
    {
        RotacionInicial = transform.localEulerAngles;
        TuboDistancia = topTransform.localPosition.y - (goalTransform.localPosition.y + 0.1f);
        LoadStage(0);
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
        Stage stage = allStages[Mathf.Clamp(stageNumber, 0, allStages.Count-1)];

        if(stage == null)
        {
            Debug.Log("No Stages");
            return;
        }

        Camera.main.backgroundColor = allStages[stageNumber].stageBackgroundColor;

        FindObjectOfType<PelotaController>().GetComponent<Renderer>().material.color = allStages[stageNumber].stageBallColor;

        transform.localEulerAngles = RotacionInicial;

        foreach(GameObject go in spawnedLevels)
        {
            Destroy(go);
        }

        float NivelDistancia = TuboDistancia/stage.Niveles.Count;
        float spawnPosY = topTransform.localPosition.y;

        for (int i = 0; i < stage.Niveles.Count; i++)
        {
            spawnPosY-= NivelDistancia;

            GameObject nivel = Instantiate(TuboLevelPrefab, transform);

            nivel.transform.localPosition = new Vector3(0, spawnPosY, 0);

            spawnedLevels.Add(nivel);

            int partsToDisable = 12 - stage.Niveles[i].partCount;

            List<GameObject> disabledParts = new List<GameObject>();

            while (disabledParts.Count < partsToDisable)
            {
                GameObject randomPart = nivel.transform.GetChild(Random.Range(0, nivel.transform.childCount)).gameObject;
                if(!disabledParts.Contains(randomPart))
                {
                    randomPart.SetActive(false);
                    disabledParts.Add(randomPart);
                }
            }
            List<GameObject> leftParts = new List<GameObject>();

            foreach (Transform item in nivel.transform)
            {
                item.GetComponent<Renderer>().material.color = allStages[stageNumber].stagePartColor;
                if(item.gameObject.activeInHierarchy)
                {
                    leftParts.Add(item.gameObject);
                }
            }
            List<GameObject> deathParts = new List<GameObject>();

            while (deathParts.Count < stage.Niveles[i].deathPartCount)
            {
                GameObject randomPart = leftParts[(Random.Range(0, leftParts.Count))];

                if(!deathParts.Contains(randomPart))
                {
                    randomPart.gameObject.AddComponent<DeathPart>();
                    deathParts.Add(randomPart);
                }
            }
        }
    }
}
