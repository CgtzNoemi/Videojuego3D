using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Nivel 
{
   [Range(1,11)]
   public int partCount = 11;
   
   [Range(0,11)]
   public int deathPartCount = 1;

    [Range(0, 11)]
    public int spacePartCount = 1;

    [Range(0, 1)]
    public int PlanetCount = 1;

    [Range(0, 1)]
    public int SolCount = 1;
}

[CreateAssetMenu(fileName = "New Stage")]
public class Stage : ScriptableObject
{
    public Color stageBackgroundColor = Color.white;
    public Color stagePartColor = Color.white;
    public Color stageBallColor = Color.white;

    public List<Nivel> Niveles = new List<Nivel>();

}

