using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using mariusPackage;

public class playerShootinh : MonoBehaviour {

    public GameObject shots, bulletSpawn;

    private Vector3 fixedPos;

    new Button();

	void Start () {


        Button b = null;

        b = new Button();


        new Button();
        

	}
	
	







	void Update () {

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject skudd = Instantiate(shots, bulletSpawn.transform.position, Quaternion.identity) as GameObject;
            skudd.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 100);

        }
    }

}
