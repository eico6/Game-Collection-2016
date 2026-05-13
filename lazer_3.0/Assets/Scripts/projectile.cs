using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour {

    public float Damage = 1f;
    public float getDamage()
    {
        return Damage;
    }

    public void Hit()
    {
        Destroy(gameObject);
    }

}
