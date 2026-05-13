using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testin : MonoBehaviour {

    public int health;

	// Use this for initialization
	public void Start () {

        DamageHealth(29);
	}

    public void Update()
    {
        if (health <= 70)
            Debug.Log("You have little Hp:" + health);

        else if (health >= 72)
            Debug.Log("That's what I'm talking about.");

        else
            Debug.Log("You have 71 man! And I know it.");

    }

    public void DamageHealth(int damage)
    {
        health -= damage;
    }

}
