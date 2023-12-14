using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NewWaveManager : MonoBehaviour
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
    public GameObject SpeechBubble;

    public GameObject finishScreen;
    public GameObject deathScreen;
    public GameObject player1WinScreen;
    public GameObject player2WinScreen;
    public GameObject continueScreen;

    [Header("Timers")]
    public float Phase1Time;
    public float Phase2Time;
    public float Phase3Time;
    public float Phase4Time;
    public float Phase5Time;
    public float Phase6Time;
    public float DifficultyModifier = 1;
    public float StartingTime;
    public float finishScreenTime;
    public float deathScreenTime;

    [Header("SFX")]
    public AudioClip Skquawk;
    public AudioClip Rumbling;
    public AudioClip Falling;

    [Header("Components")]
    public AudioSource audSource;
    public Animator Toucan;
    public NewHex CurrentHex;

    [Header("Other")]
    public int randomizedNumber;
    public GameObject Player1;
    public GameObject Player2;
    public bool isMultiplayer;
    public bool isAwake;
    public GameObject Cloud;
    public int SpeedUp1;
    public int SpeedUp2;
    public int SpeedUp3;
    public int SpeedUp4;
    public int DebugCount;
    public int DebugCount2;

    void Start()
    {
        StartCoroutine(Starting());
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
            CurrentHex = Hexer.GetComponent<NewHex>();

            if (CurrentHex.assignedNumber == randomizedNumber)
            {
                CurrentHex.SelectSymbol();
                DebugCount++;
            }
            else if (CurrentHex.assignedNumber != randomizedNumber)
            {
                CurrentHex.FallDown();
                DebugCount2++;
            }
        }

    }

    //Activates at the end of the RoundTimer() Coroutine.
    //counts the total amount of waves.
    void EndOfCycle()
    {
        waveNumber++;

        if (Player1 != null && isMultiplayer == false)
        {
            scoreDisplay.text = $"Score: {waveNumber}";
            scoreDisplay.text = $"{waveNumber}";
        }

        foreach (GameObject Symbol in symbols)
        {
            Symbol.SetActive(false);
        }

        //If wavemanager is equal to a specific number, then DifficultyModifier gets reduced, making the rounds go faster.
        if(waveNumber == SpeedUp1)
        {
            DifficultyModifier = 0.8f;
        }
        else if (waveNumber == SpeedUp2)
        {
            DifficultyModifier = 0.6f;
        }
        else if (waveNumber == SpeedUp3)
        {
            Cloud.SetActive(true);
        }
        else if (waveNumber == SpeedUp4)
        {
            DifficultyModifier = 0.3f;
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

    //When Activated, will pause all coroutines into this script.
    //Deletes the gameobject this script is attached to.
    void ShutDown()
    {
        Destroy(gameObject);
    }

    //Decides how long it should takes between Rounds.
    //Activates all needed methods to correctly run a round.
    IEnumerator RoundTimer()
    {

        yield return new WaitForSeconds(Phase1Time * DifficultyModifier);

        AssignChosenOne();
        audSource.PlayOneShot(Skquawk);
        SpeechBubble.SetActive(true);
        isAwake = true;

        yield return new WaitForSeconds(Phase2Time * DifficultyModifier);

        audSource.PlayOneShot(Rumbling);

        yield return new WaitForSeconds(Phase3Time * DifficultyModifier);

        audSource.PlayOneShot(Falling);
        SpeechBubble.SetActive(false);
        isAwake = false;

        yield return new WaitForSeconds(Phase4Time * DifficultyModifier);
        yield return new WaitForSeconds(Phase5Time * DifficultyModifier);

        EndOfCycle();

        yield return new WaitForSeconds(Phase6Time * DifficultyModifier);

        StartCoroutine(RoundTimer());
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

    //Adds a buffer to the beggining of the start of the scene, so the cycle dosen't start immediatly. 
    IEnumerator Starting()
    {
        yield return new WaitForSeconds(StartingTime);

        StartCoroutine(RoundTimer());  
    }
}
