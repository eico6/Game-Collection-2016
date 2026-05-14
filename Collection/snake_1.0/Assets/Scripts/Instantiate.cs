using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate : MonoBehaviour {

    public GameObject cube;

    private int nCubes;
    private float spawnPosition;
	
	void Start () {
		
	}
	
	
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space))
        {
            setPosition();
            nCubes++;
        }
	}

    private void setPosition()
    {
        spawnPosition = nCubes;
        spawnCube();
    }

    private void spawnCube()
    {
        Instantiate(cube, new Vector3(spawnPosition, 0, 1), Quaternion.identity);
    }

}
