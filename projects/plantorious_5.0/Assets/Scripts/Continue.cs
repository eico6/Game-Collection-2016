using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Continue : MonoBehaviour {

    private LevelManager levelManager;
    private GameTimer gameTimer;

	void Start () {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
    }

    private void OnMouseDown()
    {
        WinButton.isRoundOver = false;
        print("isRoundOver = " + WinButton.isRoundOver);

        // Reset defender selection, MEGA bad solution
        Button.selectedDefender = null;

        levelManager.LoadNextLevel();
    }

}
