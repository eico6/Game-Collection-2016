using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera2 : MonoBehaviour
{

    public LevelManager poop;
    private AudioSource sound;

    void Awake()
    {
        Cursor.visible = true;
        sound = GameObject.Find("PersistentMusic").GetComponent<AudioSource>();
        sound.volume = 0.16f;
    }

    private void Start()
    {
        sound.loop = false;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            poop.LoadLevel("Start");
            print("bais");
        }
        //print(Cursor.visible);
    }
}
