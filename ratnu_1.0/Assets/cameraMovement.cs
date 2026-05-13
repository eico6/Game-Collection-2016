using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cameraMovement : MonoBehaviour {

	
	void Start () {
        this.transform.GetComponent<Rigidbody>().AddForce(0, 0, transform.position.z * Time.deltaTime * 200);
    }

    public void Loadgame()
    {
        SceneManager.LoadScene("Game");
    }
}
