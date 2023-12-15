using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunctionList : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BackToTitle()
    {
        SceneManager.LoadScene("Title");
    }

    public void LoadHex()
    {
        SceneManager.LoadScene("Hex Score Attack");
    }
    public void LoadHexMulti()
    {
        SceneManager.LoadScene("Hex Multiplayer");
    }

    public void Quit()
    {
        Debug.Log("We all know where this is going, so lets just skip to the end!");
        Application.Quit();
    }

    //Method to load  a new scene
    public void StartNewScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
