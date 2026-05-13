using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarExplosion : MonoBehaviour {

    public ParticleSystem starExplosion;

    private Vector3 starEffectSpawn;
    private Vector3 rotation;

    private void SpawnStarExplsoion()
    {
        rotation = new Vector3(90f, 50f, 0);
        starEffectSpawn = new Vector3(transform.position.x, transform.position.y + 0.3f, -3f);
        Instantiate(starExplosion, starEffectSpawn, Quaternion.Euler(new Vector3(0, 0, 90)));
    }
	
	
	void Update () {
		
	}
}
