using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class enemyBehaviour : MonoBehaviour {

    public float health = 2f;
    public float projectileSpeed = 15f;
    public GameObject projectile;
    public float shotsPerSecond = 0.5f;
    public int scoreValue = 50;
    public AudioClip fireSound;
    public AudioClip deathSound;
    public GameObject particleDeath;
    public GameObject particleHit;
    public GameObject pointsAcquire;

    private EnemySpawner enemySpawner;
    private LevelManager levelManager;
    private scoreKeeper scoreKeeper;

    private void Start()
    {
        scoreKeeper = GameObject.Find("Score").GetComponent<scoreKeeper>();
        enemySpawner = GameObject.FindObjectOfType<EnemySpawner>();
        levelManager = GameObject.FindObjectOfType<LevelManager>();
    }

    void Update()
    {
        float probability = Time.deltaTime * shotsPerSecond;
        if (Random.value < probability)
        {
            Fire();
        }

    }


    void Fire()
    {
        Vector3 newPosition = transform.position + new Vector3(0f, -0.8f, 0f);
        GameObject missile = Instantiate(projectile, newPosition, Quaternion.identity) as GameObject;
        missile.GetComponent<Rigidbody2D>().velocity = new Vector3(0, -projectileSpeed, 0);
        AudioSource.PlayClipAtPoint(fireSound, transform.position);
    }


    void OnTriggerEnter2D(Collider2D collider)
    {
        projectile missile = collider.gameObject.GetComponent<projectile>();
        missile.Hit();

        if (missile)
        {
            health -= missile.getDamage();
            spawnHitEffect();
        }

        if (health <= 0)
        {
            die();

            if (enemySpawner.enemiesLeft <= 0)
            {
                enemySpawner.SpawnUntilFull();
            //    levelManager.LoadLevel("Win Screen");
            }
        }

    }

    void die()
    {
        scoreKeeper.Score(scoreValue);
        enemySpawner.enemiesLeft--;
        AudioSource.PlayClipAtPoint(deathSound, transform.position, 1.5f);
        spawnDeathEffect();
        acquirePoints();
        Destroy(gameObject);
    }

    void spawnDeathEffect()
    {
        GameObject smokePuff = Instantiate(particleDeath, gameObject.transform.position, Quaternion.identity);
        ParticleSystem.MainModule smoke = smokePuff.GetComponent<ParticleSystem>().main;//main som er hovud settings i den, her er det smoke
        Destroy(smokePuff, smoke.duration+2);
    }

    void spawnHitEffect()
    {
        GameObject smokePuff = Instantiate(particleHit, gameObject.transform.position, Quaternion.identity);
        ParticleSystem.MainModule smoke = smokePuff.GetComponent<ParticleSystem>().main;//main som er hovud settings i den, her er det smoke
        Destroy(smokePuff, smoke.duration + 2);
    }

    void acquirePoints()
    {
        GameObject points = Instantiate(pointsAcquire, gameObject.transform.position, Quaternion.identity) as GameObject;
        ParticleSystem.MainModule smoke = points.GetComponent<ParticleSystem>().main;//main som er hovud settings i den, her er det smoke
        Destroy(points, 1f);
    }

}
