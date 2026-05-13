using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {

    public ParticleSystem explosion;

    void Start () {
		
	}
	
	
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
        Destroy(explosion, 3f);
    }
}
