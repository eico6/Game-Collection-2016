using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinButton : MonoBehaviour {

    // Camera shake animation
    private GameObject MyCamera;
    private CameraShaker MyCameraShaker;

    public GameObject continueButton;
    public GameObject ContinueText;
    public GameObject solane;

    static public bool isRoundOver = false;
    private bool isContinueInvoked = false;
    private bool isContinueSpawned = false;

    private int levelIndex = 0;


	void Awake ()
    {
        MyCamera = GameObject.Find("Game Camera");
        MyCameraShaker = MyCamera.GetComponent<CameraShaker>();

        levelIndex = SceneManager.GetActiveScene().buildIndex;

        ContinueText.SetActive(false);
    }
	
	void Update ()
    {

        if (!isContinueInvoked)
        {
            if (!isContinueSpawned && isActiveAndEnabled)
            {
                isRoundOver = true;
                print("isRoundOver = " + WinButton.isRoundOver);
                SunExplosion(true);
                Invoke("spawnContinue", 3.0f);
                isContinueInvoked = true;

                // Add extra amount of camera shake on final level 3
                if (levelIndex == 5)
                {
                    MyCameraShaker.SetCameraShake(true, true);
                }
                else
                {
                    MyCameraShaker.SetCameraShake(true);
                }
            }
        }
    }

    private void SunExplosion(bool IsExploding)
    {
        // Start sun explosion particle system 
        if (IsExploding)
        {
            solane.SetActive(true);
        }
        else
        {
            solane.SetActive(false);
        }
    }

    private void spawnContinue()
    {
        SunExplosion(false);

        // Move the dancing "you win!" text up a bit to make space.
        this.transform.Translate(0f, 0.5f, 0f, this.transform);

        ContinueText.SetActive(true);
        Instantiate(continueButton);
        isContinueSpawned = true;
    }
}
