using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour {

    public LevelManager poop;
    private AudioSource sound;

	void Awake () {
        Cursor.visible = true;
        sound = GameObject.Find("PersistentMusic").GetComponent<AudioSource>();
        sound.volume = 0.2f;
	}
	
	
	void Update () {
		if (Input.GetKey(KeyCode.Space))
        {
            poop.LoadNextLevel();
        }
        //print(Cursor.visible);
	}
}
