using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour {

    public float speed = 15.0f;
    public GameObject projectile;
    public float projectileSpeed = 8.0f;
    public float fireRate = 0.2f;
    public float health = 3f;
    public GameObject hp1;
    public GameObject hp2;
    public GameObject hp3;
    public GameObject particleDeath;
    public GameObject particleHit;
    public AudioClip damageSound;


    private float Xmin;
    private float Xmax;
    private float Ymin;
    private float Ymax;
    private float xPadding = 0.5f;
    private float yPadding = 0.8f;
    private LevelManager levelManager;
    private MusicPlayer musicPlayer;


    private void Start()
    {
        float distance = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
        Xmin = leftmost.x + xPadding;
        Xmax = rightmost.x - xPadding;

        Vector3 highest = Camera.main.ViewportToWorldPoint(new Vector3(0, 0.3f, distance));
        Vector3 lowest = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Ymax = highest.y + yPadding;
        Ymin = lowest.y + yPadding;

        hp1 = Instantiate(hp1, new Vector2(8.06f, 2.89f), Quaternion.identity) as GameObject;
        hp2 = Instantiate(hp2, new Vector2(7.11f, 2.89f), Quaternion.identity) as GameObject;
        hp3 = Instantiate(hp3, new Vector2(6.15f, 2.89f), Quaternion.identity) as GameObject;

        levelManager = GameObject.FindObjectOfType<LevelManager>();
        musicPlayer = FindObjectOfType<MusicPlayer>();

    }


    void Fire()
    {
        Vector3 newPosition = transform.position + new Vector3(0f, 0.7f, 0f);
        GameObject lazer = Instantiate(projectile, newPosition, Quaternion.identity) as GameObject;
        lazer.GetComponent<Rigidbody2D>().velocity = new Vector3(0, projectileSpeed, 0);
        GetComponent<AudioSource>().Play();
    }


    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
         else if (Input.GetKey(KeyCode.RightArrow))
        {
            //transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
         if (Input.GetKey(KeyCode.UpArrow))
        {
            //transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
            transform.position += Vector3.up * speed * Time.deltaTime;
        } 
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            //transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
            transform.position += Vector3.down * speed * Time.deltaTime;
        }


        //restricting the player to the gamespace
        float newX = Mathf.Clamp(transform.position.x, Xmin, Xmax);
        float newY = Mathf.Clamp(transform.position.y, Ymin, Ymax);
        transform.position = new Vector3(newX, newY, transform.position.z);


        if (Input.GetKeyDown(KeyCode.Space))
        {
            InvokeRepeating("Fire", 0.000001f, fireRate);
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            CancelInvoke("Fire");
        }
    }
    
        void OnTriggerEnter2D(Collider2D collider)
        {
            projectile missile = collider.gameObject.GetComponent<projectile>();
            missile.Hit();

            if (missile)
            {
                health -= missile.getDamage();
                removeHeart();
                spawnHitEffect();
                AudioSource.PlayClipAtPoint(damageSound, transform.position, 1f);
        }

            if (health <= 0)
            {
            musicPlayer.chargingLoad();
            Destroy(gameObject);
            spawnDeathEffect();
        }

    }



    void spawnDeathEffect()
    {
        GameObject smokePuff = Instantiate(particleDeath, gameObject.transform.position, Quaternion.identity);
        ParticleSystem.MainModule smoke = smokePuff.GetComponent<ParticleSystem>().main;//main som er hovud settings i den, her er det smoke
        Destroy(smokePuff, smoke.duration + 2);
    }

    void spawnHitEffect()
    {
        GameObject smokePuff = Instantiate(particleHit, gameObject.transform.position, Quaternion.identity);
        ParticleSystem.MainModule smoke = smokePuff.GetComponent<ParticleSystem>().main;//main som er hovud settings i den, her er det smoke
        Destroy(smokePuff, smoke.duration + 2);
    }



    void removeHeart()
    {
        if (health == 2)
        {
            Destroy(hp3);
        }
        else if (health == 1)
        {
            Destroy(hp2);
        }
        else if (health <= 0)
        {
            Destroy(hp1);
        }
    }


    
}
