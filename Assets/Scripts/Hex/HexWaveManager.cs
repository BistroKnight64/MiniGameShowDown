using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexWaveManager : MonoBehaviour
{
    [Header("Hexagons")]
    public List<GameObject> Hexes;
    public GameObject ChosenOne;

    [Header("Components")]
    public AudioSource audSource;

    [Header("Other")]
    public int randomizedNumber;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    //Randomizes a number, then Selects a Hexagon based on that number.
    void AssignChosenOne()
    {
        randomizedNumber = Random.Range(0, 19);

    }
}
