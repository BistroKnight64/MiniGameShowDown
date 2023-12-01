using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexWaveManager : MonoBehaviour
{
    [Header("Hexagons")]
    public List<GameObject> Hexes;
    public GameObject ChosenOne;

    [Header("Wave Managing")]
    public int WaveNumber;
    public float WaveTime;

    [Header("Components")]
    public AudioSource audSource;

    [Header("Other")]
    public List<GameObject> Symbols;
    public GameObject ChosenSymbol;
    public int randomizedNumber;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    //Randomizes a number, then Selects a Hexagon and Symbol based on that number.
    void AssignChosenOne()
    {
        //Declarations
        randomizedNumber = Random.Range(0, 22);
        ChosenSymbol = Symbols[randomizedNumber];
        Debug.Log($"randomized number is {randomizedNumber}");

        
    }
}
