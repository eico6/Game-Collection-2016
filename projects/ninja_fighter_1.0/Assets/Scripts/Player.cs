using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private LevelManager levelManager;

	void Start () {
        levelManager = FindObjectOfType<LevelManager>();
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        levelManager.LoadNextLevel();
    }

    void Update () {
		if (Input.GetKeyDown(KeyCode.Space))
        {
            levelManager.LoadNextLevel();
        }
	}
}
