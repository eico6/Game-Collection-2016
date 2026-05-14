using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public float autoLoadLevelAfter;

    private void Start()
    {
        if (autoLoadLevelAfter <= 0)
        {
            Debug.Log("Auto load disabled");
        } else if
            (SceneManager.GetActiveScene().buildIndex == 0)
        {
            Invoke("LoadNextLevel", autoLoadLevelAfter);
            Debug.Log("Auto load enabled");
        }
    }

    public void LoadLevel(string name){
        SceneManager.LoadScene(name);
    }

	public void QuitRequest(){
		Application.Quit ();
        Debug.Log("Quit requested");
	}

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
