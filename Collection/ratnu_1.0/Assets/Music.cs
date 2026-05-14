using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour {

    private AudioSource music;

    void Start () {
        GameObject.DontDestroyOnLoad(gameObject);
        music = GetComponent<AudioSource>();
        music.Play();
    }
	
	
	void Update () {
		
	}
}
