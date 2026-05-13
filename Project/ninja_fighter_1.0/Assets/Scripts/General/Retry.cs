using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Retry : MonoBehaviour
{

    private LevelManager levelManager;

    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }


    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            levelManager.LoadLevel("Start");
        }
    }
}
