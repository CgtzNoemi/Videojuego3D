using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpacePart : MonoBehaviour
{
    
    private void OnEnable()
    {
        GetComponent<Renderer>().material.color = Color.black;
    }
}
