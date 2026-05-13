using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private LevelManager levelManager;
    private AudioSource sound;

    public GameObject demon, fakeDemon;

    void Start () {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        Cursor.visible = true;
        sound = GameObject.Find("PersistentMusic").GetComponent<AudioSource>();
        sound.volume = 1f;

        fakeDemon.SetActive(true);
        demon.SetActive(false);
    }
	
	
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "AIThirdPersonController")
        {
            levelManager.LoadLevel("Win");
        } else if (other.gameObject.name == "DemonTrigger")
        {
            fakeDemon.SetActive(false);
            demon.SetActive(true);
        } else if (other.gameObject.name == "demon")
        {
            levelManager.LoadLevel("Start");
        }
    }
}
