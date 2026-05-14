using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float speed = 4.0f;
    public GameObject rightSpawner, leftSpawner, lizard;

    private float xPosition, xScale;

    void Start () {
        xPosition = transform.localPosition.x;
        xScale = transform.localScale.x;

        if (xPosition < 0.0f)
        {
            speed = -speed;
            xScale = -2f;
        }

        InvokeRepeating("spawnEnemy", 1.0f, 2.0f);
	}
	
	private void spawnEnemy()
    {
        Instantiate(lizard, leftSpawner.transform.position, Quaternion.identity);
    }

	void Update () {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
}
