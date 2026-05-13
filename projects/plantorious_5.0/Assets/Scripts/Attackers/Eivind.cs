using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Attacker))]
public class Eivind : MonoBehaviour
{

    private Animator anim;
    private Attacker attacker;

    void Start()
    {
        anim = GetComponent<Animator>();
        attacker = GetComponent<Attacker>();
    }


    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject obj = collider.gameObject;

        if (!obj.GetComponent<Defender>())
        {
            return;
        }
        else
        {
            anim.SetBool("isAttacking", true);
            attacker.Attack(obj);
        }
    }
}
