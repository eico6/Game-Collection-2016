using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firstinworld : MonoBehaviour
{

    public int health;

    void Start()
    {
        DamagePlayer(15);
    }


    void Update()
    {
        if (health <= 0)
        {
            health = 0;
            Destroy (gameObject, 5f);
            Debug.Log("The player has died! health: " + health);
            
        }
        else if (health >= 15)
        {
            print("You have a lot of life.");
        }
    }



    void DamagePlayer(int damage)
    {
        health -= damage;
    }






}
