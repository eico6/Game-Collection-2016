using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ethanMovable : MonoBehaviour {

    public LevelManager levelManager;
	
	void Start () {
		
	}
	
	
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "pickaxe")
        {
            levelManager.LoadLevel("Secret");
        }
    }
}
