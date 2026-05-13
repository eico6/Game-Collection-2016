using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST : MonoBehaviour {

	void Start () {
        print("Volume = " + PlayerPrefsManager.GetMasterVolume());


        //print(PlayerPrefsManager.IsLevelUnlocked(2));
        //PlayerPrefsManager.UnlockLevel(2);
        //print(PlayerPrefsManager.IsLevelUnlocked(2));

        print("Difficulty = " + PlayerPrefsManager.GetDifficulty());
    }
	
	void Update () {
		
	}
}
