using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brick : MonoBehaviour {

    public AudioClip crack, FourHp;
    public Sprite[] hitSprites;
    public static int breakableCount = 0;
    public GameObject Smoke;
    public GameObject Smoke_1hit;
    public GameObject BigSmoke;
    public GameObject BigSmoke_1hit;
    public GameObject EivindSmoke;

    private bool EivSpawnet = false;
    private int timesHit;
    private LevelManager LevelManager;
    private bool isBreakable;


    void Start () {
        isBreakable = (this.tag == "breakable");

        if (isBreakable)
        {
            breakableCount++;
        }

        timesHit = 0;
        LevelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (isBreakable)
        {
            HandleHits();
            if (transform.localScale.y > 1)
            {
                AudioSource.PlayClipAtPoint(crack, transform.position, 2f);
            }
            AudioSource.PlayClipAtPoint(crack, new Vector3(8f, 6f, 0f), 0.40f);
        }

    }


    void HandleHits()
    {
        timesHit++;
        int maxHits = hitSprites.Length + 1;
        if (transform.localScale.y > 1)
        {
            maBoys();
        }

        if (transform.localScale.y > 1)
        {
            spawnEivindSmoke();
            EivSpawnet = true;
        }
        if (timesHit >= maxHits)
        {
            breakableCount--;
            LevelManager.BrickDestroyed();
            Destroy(gameObject);
            if (transform.localScale.x == 6)
            {
                spawnBigSmoke();
            } else if (EivSpawnet == false)
            spawnSmoke();
        }
        else
        {
            LoadSprites();
        }
    }



    //WHAT IS THIS RIGHT HERE, LOOK AT THIS IN FUTURE, ONLY THING I DIDN'T COMPLETELY UNDERSTAND IS THIS  //WHAT IS THIS RIGHT HERE, LOOK AT THIS IN FUTURE, ONLY THING I DIDN'T COMPLETELY UNDERSTAND IS THIS

    void spawnSmoke()
    {
        GameObject smokePuff = Instantiate(Smoke, gameObject.transform.position, Quaternion.identity);
        ParticleSystem.MainModule smoke = smokePuff.GetComponent<ParticleSystem>().main;//main som er hovud settings i den, her er det smoke
        smoke.startColor = GetComponent<SpriteRenderer>().color;
        Destroy(smokePuff, smoke.duration);
    }

    void spawnBigSmoke()
    {
        GameObject smokePuff = Instantiate(BigSmoke, gameObject.transform.position, Quaternion.identity);
        ParticleSystem.MainModule smoke = smokePuff.GetComponent<ParticleSystem>().main;//main som er hovud settings i den, her er det smoke
        smoke.startColor = GetComponent<SpriteRenderer>().color;
        Destroy(smokePuff, smoke.duration);
    }

    void spawnLesserSmoke()
    {
        GameObject lesserPuff = Instantiate(Smoke_1hit, gameObject.transform.position, Quaternion.identity);
        ParticleSystem.MainModule smoke = lesserPuff.GetComponent<ParticleSystem>().main;
        smoke.startColor = GetComponent<SpriteRenderer>().color;
        Destroy(lesserPuff, smoke.duration);
    }

    void spawnBigSmoke_1hit()
    {
        GameObject lesserPuff = Instantiate(BigSmoke_1hit, gameObject.transform.position, Quaternion.identity);
        ParticleSystem.MainModule smoke = lesserPuff.GetComponent<ParticleSystem>().main;
        smoke.startColor = GetComponent<SpriteRenderer>().color;
        Destroy(lesserPuff, smoke.duration);
    }

    void spawnEivindSmoke()
    {
        GameObject lesserPuff = Instantiate(EivindSmoke, gameObject.transform.position, Quaternion.identity);
        ParticleSystem.MainModule smoke = lesserPuff.GetComponent<ParticleSystem>().main;
        Destroy(lesserPuff, smoke.duration);
    }


    //WHAT IS THIS RIGHT HERE, LOOK AT THIS IN FUTURE, ONLY THING I DIDN'T COMPLETELY UNDERSTAND IS THIS  //WHAT IS THIS RIGHT HERE, LOOK AT THIS IN FUTURE, ONLY THING I DIDN'T COMPLETELY UNDERSTAND IS THIS

    void LoadSprites()
    {
        int element = timesHit - 1;
        if (hitSprites[element])
        {
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[element];
            if (transform.localScale.x == 6)
            {
                spawnBigSmoke_1hit();
            } else if (EivSpawnet == false)
            spawnLesserSmoke();
        } else
        {
            Debug.LogError("Brick sprite missing! boiiii!");
        }
    }

    //TODO Fjern denne "method" når du kan vinne
    void SimulateWin()
    {
        LevelManager.LoadNextLevel();
    }


	void Update () {
        if (Input.GetKeyDown(KeyCode.W))
        {
            SimulateWin();
        }
    }

    void maBoys()
    {
        if (hitSprites.Length <= 4)
        {
            AudioSource.PlayClipAtPoint(FourHp, new Vector3(8f, 6f, 0f), 0.8f);
        }
    }
}
