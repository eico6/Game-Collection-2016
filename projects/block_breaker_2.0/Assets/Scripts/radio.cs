using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class radio : MonoBehaviour {
    public AudioClip FullHp;


    // Use this for initialization
    void Awake () {
        AudioSource.PlayClipAtPoint(FullHp, new Vector3(8f, 6f, 0f), 0.6f);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
