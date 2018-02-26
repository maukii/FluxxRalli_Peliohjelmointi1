using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour {
    private void Update()
    {
        
    }
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Game is exiting");
    }
}
