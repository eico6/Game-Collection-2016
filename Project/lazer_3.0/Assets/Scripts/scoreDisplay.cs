using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class scoreDisplay : MonoBehaviour {

    private LevelManager levelManager;

	// Use this for initialization
	void Start () {
        Text myText = GetComponent<Text>();
        myText.text = scoreKeeper.score.ToString();
        scoreKeeper.Reset();

        levelManager = FindObjectOfType<LevelManager>();
	}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || (Input.GetKeyDown(KeyCode.Return)))
        {
            levelManager.LoadLevel("Start Menu");
        }
    }

}
