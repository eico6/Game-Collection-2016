using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour {

    public GameObject[] attackerPrefabArray;

    private int levelIndex;

    private void Start()
    {
        levelIndex = SceneManager.GetActiveScene().buildIndex;
    }

    void Update ()
    {
        if (Time.timeSinceLevelLoad > 10f)
        {
            SpawnAttackers();
            print("Spawning Attackers");
        }
    }

    private void SpawnAttackers()
    {
        foreach (GameObject thisAttacker in attackerPrefabArray)
        {
            if (isTimeToSpawn(thisAttacker))
            {
                Spawn(thisAttacker);
            }
        }
    }

    bool isTimeToSpawn(GameObject attackerGameObject)
    {
        Attacker attacker = attackerGameObject.GetComponent<Attacker>();

        float meanSpawnDelay = attacker.seenEverySeconds;
        float spawnsPerSecond = 1 / meanSpawnDelay;

        if(Time.deltaTime > meanSpawnDelay)
        {
            Debug.LogWarning("Spawn rate capped by frame rate");
        }

        float threshold = spawnsPerSecond * Time.deltaTime / 5;

        if (GameTimer.slider.value > 0.6f)
        {
            threshold *= 5f;
            print("Increasing Difficulty");
        }

        if (GameTimer.slider.value > 0.8f && levelIndex == 5)
        {
            threshold *= 8f;
            print("SUPER MODE!");
        }

        if (GameTimer.slider.value > 0.92f && levelIndex == 5)
        {
            threshold *= 13f;
            print("STYYYYGT!");
        }

        return (Random.value < threshold);
    }

    private void Spawn(GameObject myGameObject)
    {
        GameObject myAttacker = Instantiate(myGameObject) as GameObject;
        myAttacker.transform.parent = transform;
        if (myAttacker.GetComponent<Lizard>() || myAttacker.GetComponent<Eivind>())
        {
            myAttacker.transform.position = new Vector3(transform.position.x-2.5f, transform.position.y, transform.position.z);
        } else 
        myAttacker.transform.position = transform.position;
    }
}
