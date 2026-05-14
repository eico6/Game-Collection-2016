using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public void LoadLevel (string NameOfLevel)
    {
        Debug.Log("Load level request: " + NameOfLevel);
        Application.LoadLevel(NameOfLevel);
    }

    public void QuitRequest ()
    {
        Debug.Log("I want to quit!");
        Application.Quit();
    }
}
