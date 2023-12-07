using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HexWaveManager : MonoBehaviour
{
    [Header("Hexagons")]
    public List<GameObject> hexes;
    public GameObject chosenOne;

    [Header("Wave Managing")]
    public int waveNumber;
    public float roundTime;

    [Header("Displays")]
    public TextMeshProUGUI scoreDisplay;
    public TextMeshProUGUI scoreDisplay2;
    public List<GameObject> symbols;
    public GameObject chosenSymbol;

    public GameObject finishScreen;
    public GameObject deathScreen;
    public GameObject player1WinScreen;
    public GameObject player2WinScreen;
    public GameObject continueScreen;

    [Header("Components")]
    public AudioSource audSource;
    public Hex CurrentHex;

    [Header("Other")]
    public int randomizedNumber;
    public GameObject Player1;
    public GameObject Player2;
    public bool isMultiplayer;
    public float finishScreenTime;
    public float deathScreenTime;
    public int DebugCount;
    public int DebugCount2;

    void Start()
    {
        StartCoroutine(RoundTimer());   
    }

    void FixedUpdate()
    {
        DeathOfPlayer();
    }

    //Randomizes a number, then Selects a Hexagon based on that number.
    void AssignChosenOne()
    {
        //Declarations
        randomizedNumber = Random.Range(0, 7);
        chosenOne = hexes[randomizedNumber];
        DebugCount = 0;
        DebugCount2 = 0;

        //Activates FallDown() in every Hex except the chosen one.
        //Activates SelectSymbol() in the ChosenOne;
        foreach (GameObject Hexer in hexes)
        {
            CurrentHex = Hexer.GetComponent<Hex>();

            if (CurrentHex.assignedNumber == randomizedNumber)
            {
                CurrentHex.SelectSymbol();
                DebugCount++;
            }
            else if( CurrentHex.assignedNumber != randomizedNumber) 
            {
                CurrentHex.FallDown();
                DebugCount2++;
            }
        }

    }

    //Detects if one of the players is dead. Then, it runs the Results Coroutine.
    void DeathOfPlayer()
    {
        if (Player1 == null)
        {
            StartCoroutine(Results());
            Debug.Log("Player 1 has perished!");
        }
        else if (Player2 == null && isMultiplayer == true)
        {
            StartCoroutine(Results());
            Debug.Log("Player 2 has perished!");
        }
    }

    //Decides how long it should takes between Rounds.
    //Activates all needed methods to correctly run a round.
    IEnumerator RoundTimer()
    {
        AssignChosenOne();

        yield return new WaitForSeconds(roundTime);

        if(Player1 != null && isMultiplayer == false)
        {
            waveNumber++;
            scoreDisplay.text = $"Score: {waveNumber}";
            scoreDisplay.text = $"{waveNumber}";
        }

        foreach (GameObject Symbol in symbols)
        {
            Symbol.SetActive(false);
        }

        StartCoroutine(RoundTimer());
    }

    //When Activated, will pause all coroutines into this script.
    //Deletes the gameobject this script is attached to.
    void ShutDown()
    {
        Destroy(gameObject);
    }

    //Brings up the finish screen, then brings up a different screen aftera set time.
    //What different screen depends on is the game was in multiplayer mode or not, and which player died.
    IEnumerator Results()
    {
        //Brings up Finish Screen, and pauses coroutine.
        
        finishScreen.SetActive(true);

        yield return new WaitForSeconds(finishScreenTime);

        if (isMultiplayer == false && Player1 == null)
        {
           deathScreen.SetActive(true);
           
        }
        else if (isMultiplayer == true && Player1 == null)
        {
            player2WinScreen.SetActive(true);
           
        }
        else if (isMultiplayer == true && Player2 == null)
        {
            player1WinScreen.SetActive(true);
        }

        ShutDown();
    }
}