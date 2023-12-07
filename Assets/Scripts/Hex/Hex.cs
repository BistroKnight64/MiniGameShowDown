using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hex : MonoBehaviour
{
    public int assignedNumber;
    public List<GameObject> symbols;
    public GameObject selectedSymbol;
    public int randomNumber;
    public bool isShaking;
    public Animator animator;
    public AudioSource audiosource;
    public HexWaveManager wave;
    public float RumbleTime;
    public float FallingTime;
    public float FallingSpeed;
    public int sequencephase;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(sequencephase == 1)
        {
            transform.Translate(Vector3.forward * FallingSpeed * Time.deltaTime);
        }
        else if(sequencephase == 2)
        {
            transform.Translate(Vector3.back * FallingSpeed * Time.deltaTime);
        }
        else
        {

        }
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
        yield return new WaitForSeconds(RumbleTime);

        sequencephase = 1;

        yield return new WaitForSeconds(FallingTime);

        sequencephase++;

        yield return new WaitForSeconds(FallingTime);

        sequencephase = 0;
    }
}
