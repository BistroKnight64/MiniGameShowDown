using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ScreenInputtrg : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartScoreAttack(InputAction.CallbackContext context)
    {
        SceneManager.LoadScene("Hex Score Attack");
    }

    public void TitleReturn(InputAction.CallbackContext context)
    {

    }

    public void Multiplayer(InputAction.CallbackContext context)
    {

    }
}
