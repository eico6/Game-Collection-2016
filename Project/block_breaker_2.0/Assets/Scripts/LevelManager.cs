using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string name){
        SceneManager.LoadScene(name);
        brick.breakableCount = 0;
    }

	public void QuitRequest(){
		Application.Quit ();
	}

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        brick.breakableCount = 0;
    }

    public void BrickDestroyed()
    {
        if (brick.breakableCount <= 0)
        {
            LoadNextLevel();
        }
    }

}
