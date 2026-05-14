using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class radio2 : MonoBehaviour
{
    public AudioClip ZeroHp;


    // Use this for initialization
    void Start()
    {
        Cursor.visible = true;
        if (transform.position.x > 1.5499)
        {
            AudioSource.PlayClipAtPoint(ZeroHp, new Vector3(0f, 0f, 0f), 0.8f);
        }
        AudioSource.PlayClipAtPoint(ZeroHp, new Vector3(0f, 0f, 0f), 0.2f);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
