using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour {

    public Slider volumeSlider; //and difficultySlider;
    public LevelManager levelManager;

    private MusicManager musicManager;
	
	void Start () {
        musicManager = GameObject.FindObjectOfType<MusicManager>();

        volumeSlider.value = PlayerPrefsManager.GetMasterVolume();
        //difficultySlider.value = PlayerPrefsManager.GetDifficulty();
	}
	
	
	void Update () {
        musicManager.SetVolume(volumeSlider.value);
	}

    public void SaveAndExit()
    {
        PlayerPrefsManager.SetMasterVolume(volumeSlider.value);
        //PlayerPrefsManager.SetDifficulty(difficultySlider.value);
        levelManager.LoadLevel("01a Start");
    }

    public void SetDefaults()
    {
        volumeSlider.value = 0.5f;
        //difficultySlider.value = 2.0f;
    }
}
