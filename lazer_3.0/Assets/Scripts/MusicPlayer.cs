using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {
	static MusicPlayer instance = null;

    public AudioClip startMusic;
    public AudioClip gameMusic;
    public AudioClip endMusic;
    public AudioClip endEndMusic;

    private AudioSource music;
    private LevelManager levelManager;

	void Start () {
        levelManager = FindObjectOfType<LevelManager>();

        if (instance != null && instance != this) {
			Destroy (gameObject);
			print ("Duplicate music player self-destructing!");
		} else {
			instance = this;
			GameObject.DontDestroyOnLoad(gameObject);
            music = GetComponent<AudioSource>();
            music.clip = startMusic;
            music.loop = true;
            music.Play();
        }
	}


    public void OnLevelWasLoaded(int level)
    {
        Debug.Log("MusicPlayer: loaded level " + level);
        music.Stop();

        if (level == 0)
        {
            music.volume = 0.7f;
            music.clip = startMusic;
        }
        else if (level == 1)
        {
            music.volume = 0.15f;
            music.clip = gameMusic;
            Cursor.visible = false;
        } else if (level == 2)
        {
            music.volume = 0.4f;
            music.clip = endEndMusic;
            Cursor.visible = true;
        }

        music.loop = true;
        music.Play();

    }


    public void playDaTheme()
    {
        music.Stop();
        music.volume = 0.4f;
        music.clip = endMusic;
        music.loop = true;
        music.Play();
    }



    public void chargingLoad()
    {
        Invoke("LoadLevel", 2f);
        playDaTheme();
    }

    void LoadLevel()
    {
        levelManager.LoadLevel("Win Screen");
    }




}
