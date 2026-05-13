using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenuStart : MonoBehaviour {

    private LevelManager levelManager;

    private void Start()
    {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
    }

    void Update () {
		if (Input.GetKeyDown(KeyCode.Space) || (Input.GetKeyDown(KeyCode.Return)))
        {
            levelManager.LoadLevel("Game");
        }
	}
}
