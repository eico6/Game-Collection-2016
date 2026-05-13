using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameTimer : MonoBehaviour {

    private GameObject WinLabel;
    private AudioSource persistentMusic;

    public bool isEndOfLevel = false;
    public static Slider slider;
    public float timeForCompletion = 10f;

    void Start () {
        slider = GetComponent<Slider>();
        FindYouWinLabel();
        WinLabel.SetActive(false);

        // If MusicManager has been initialized correctly.
        if (GameObject.Find("Persistent Music"))
        {
            persistentMusic = GameObject.Find("Persistent Music").GetComponent<AudioSource>();
            persistentMusic.loop = false;
        }
	}
    
    private void FindYouWinLabel()
    {
        WinLabel = GameObject.Find("You Win");
        if (!WinLabel)
        {
            Debug.LogError("Can't find You Win object - Eiivnd Naasen");
        }
    }
	
	void Update () {
        // Deubbing
        if (Input.GetKey(KeyCode.O))
        {
            CompleteTimer();
        }

        UpdateSlider();
    }

    // debugging
    private void CompleteTimer()
    {
        timeForCompletion = Time.timeSinceLevelLoad;
    }

    private void UpdateSlider()
    {
        slider.value = Time.timeSinceLevelLoad / timeForCompletion;

        if (slider.value >= 1 && !isEndOfLevel)
        {
            isEndOfLevel = true;
            Destroy(GameObject.Find("Projectiles"));
            Destroy(GameObject.Find("Spawners"));
            Destroy(GameObject.Find("Defenders"));
            WinLabel.SetActive(true);
        }
    }
}
