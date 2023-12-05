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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void FallDown()
    {
     
    }

    public void SelectSymbol()
    {
        randomNumber = Random.Range(0, 0);
        selectedSymbol = symbols[randomNumber];
        Debug.Log($"selectedSymbol is {symbols[randomNumber]}");
        
        selectedSymbol.SetActive(true);
    }

    IEnumerator FallingSequence()
    {
        yield return new WaitForSeconds(RumbleTime);

        transform.Translate(Vector3.down * FallingSpeed * Time.deltaTime);

        yield return new WaitForSeconds(FallingTime);

        transform.Translate(Vector3.up * FallingSpeed * Time.deltaTime);

        yield return new WaitForSeconds(FallingTime);
    }
}
