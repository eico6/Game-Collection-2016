using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightDetector : MonoBehaviour {

    public ParticleSystem death;

    private bool canAttack;
    private GameObject enemyColiding;

	void Start () {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        enemyColiding = collision.gameObject;
        canAttack = true;
    }

    void Update () {
		if (canAttack && Input.GetKey(KeyCode.RightArrow))
        {
            Destroy(enemyColiding);
            Instantiate(death, enemyColiding.transform.position, Quaternion.identity);
        }
	}
}
