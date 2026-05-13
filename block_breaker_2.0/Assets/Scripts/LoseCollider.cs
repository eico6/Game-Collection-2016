using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour {

    private LevelManager LevelManager;

    private void Start()
    {
        LevelManager = GameObject.FindObjectOfType<LevelManager>();
    }

    void OnTriggerEnter2D(Collider2D trigger)
    {
        LevelManager.LoadLevel("Lose Screen");
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //print("Collision");
    }
}
