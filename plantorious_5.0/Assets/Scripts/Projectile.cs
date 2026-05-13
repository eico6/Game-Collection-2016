using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float speed, damage;
    public ParticleSystem hitEffect;
    public AudioClip start;

    private Vector3 hitEffectSpawn;

    void Update () {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Attacker attacker = collision.GetComponent<Attacker>();
        Health health = collision.GetComponent<Health>();
        hitEffectSpawn = new Vector3(collision.transform.position.x, collision.transform.position.y, -3f);

        if (attacker && health)
        {
            health.DealDamage(damage);

            // Start hit effect either green or red, depending on whether it was the axe or the courgette.
            if (hitEffect.name == "Axe hit")
            {
                attacker.HitColorEffect(true);
            }
            else
            {
                attacker.HitColorEffect(false);
            }

            Instantiate(hitEffect, hitEffectSpawn, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
