using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour {

    //  Janne Viitala
    private void Update()
    {
        
    }
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Game is exiting");
    }
    public void LoadScene(int level)
    {
        Application.LoadLevel(level);
    }
}

