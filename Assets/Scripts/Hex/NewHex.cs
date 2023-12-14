using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewHex : MonoBehaviour
{
    public int assignedNumber;
    public List<GameObject> symbols;
    public GameObject selectedSymbol;
    public int randomNumber;
    public bool isShaking;
    public Animator animator;
    public NewWaveManager wave;
    public GameObject HexCollide;
    public GameObject HexSprite;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }

    public void FallDown()
    {
        StartCoroutine(FallingSequence());

    }

    public void SelectSymbol()
    {
        randomNumber = Random.Range(0, 3);
        selectedSymbol = symbols[randomNumber];

        selectedSymbol.SetActive(true);
    }

    IEnumerator FallingSequence()
    {
        yield return new WaitForSeconds(1 * wave.DifficultyModifier);

        animator.SetBool("Shaking", true);



        yield return new WaitForSeconds(5 * wave.DifficultyModifier);
             
    }
}
