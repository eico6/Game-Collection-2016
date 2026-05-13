using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Classen Fox er på ein måte child til attacker, gir ikkje meining uten attacker. Så visst eg adder Fox script seinere til nytt gameobject, og glømmer attacker script, blir den adda automatiskt.
[RequireComponent(typeof(Attacker))] 
public class Fox : MonoBehaviour {

    private Animator anim;
    private Attacker attacker;
	
	void Start () {
        anim = GetComponent<Animator>();
        attacker = GetComponent<Attacker>();
	}
	
	
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject obj = collider.gameObject;

        if (!obj.GetComponent<Defender>())
        {
            // visst colliding object (obj) IKKJE har defender script, return (leave method). "Hopper" over resten av tullet.
            return;
        }

        if (obj.GetComponent<Stone>())
        {
            anim.SetTrigger("jump trigger");
        }
        else
        {
            anim.SetBool("isAttacking", true);
            attacker.Attack(obj);
        }
    }
}
