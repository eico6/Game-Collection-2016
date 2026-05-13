using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody2D))]
public class Attacker : MonoBehaviour {

    [Tooltip("Average number of seconds between appearances")]
    public float seenEverySeconds;

    private float currentSpeed;
    private GameObject currentTarget;
    private Animator anim;

    // Body sprite color update
    public GameObject body; // this is public to just easily drag the reference into the editor joint.
    private SpriteRenderer bodySprite;
    private Color newColor;
    private bool isHit = false;
    private float timePassedSinceHit = 0f;
    private float hitEffectDuration = 0.6f; // You can change this to set how long the hit effect should last.
    bool isAxe = false;
    float newRed = 0f;
    float newGreen = 0f;
    float newBlue = 0f;

    void Start () {
        //Rigidbody2D myRigidbody = gameObject.AddComponent<Rigidbody2D>();
        //myRigidbody.isKinematic = true;
        anim = GetComponent<Animator>();

        bodySprite = body.GetComponent<SpriteRenderer>();
	}
	
	
	void Update () {
        // Makes the attacker walk forward
        transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
        
        // Makes the attacker attack
        if (!currentTarget)
        {
            anim.SetBool("isAttacking", false);
        }

        // If attacker is hit by a projectile
        if (isHit)
        {
            // Sets new color 
            bodySprite.color = newColor;

            // Updates timePassedSinceHit
            timePassedSinceHit += Time.deltaTime;
            // Makes the value never be able to exceed the hitDuration which is important for color input.
            if (timePassedSinceHit > hitEffectDuration) timePassedSinceHit = hitEffectDuration;

            // Calculates the new color values, depending on whether it was an ax, or a courgette projectile.
            if (isAxe)
            {
                newGreen = timePassedSinceHit / hitEffectDuration;
                newBlue = timePassedSinceHit / hitEffectDuration;
            } else
            {
                newRed = timePassedSinceHit / hitEffectDuration;
                newBlue = timePassedSinceHit / hitEffectDuration;
            }

            newColor = new Color(newRed, newGreen, newBlue, 1f);

            // It's been hitEffectDuration seconds, so reset hit status.
            if (timePassedSinceHit == hitEffectDuration)
            {
                isHit = false;
                timePassedSinceHit = 0f;
                bodySprite.color = new Color(1f, 1f, 1f, 1f);
            }
        }
	}

    private void OnTriggerEnter2D()
    {
        //Debug.Log(name +"(Trigger Happend");
    }

    public void SetSpeed (float speed)
    {
        currentSpeed = speed;
    }

    // Called from the animator at time of actual blow
    public void StrikeCurrentTarget(float damage)
    {
        if (currentTarget)
        {
            Health Hp = currentTarget.GetComponent<Health>();
            if (Hp)
            {
                Hp.DealDamage(damage);
            }
        }
    }

    public void Attack(GameObject obj)
    {
        currentTarget = obj;
    }

    // Fargen på selve spriten til enemy
    public void HitColorEffect(bool isAxeIn)
    {
        isHit = true;
        isAxe = isAxeIn;
        timePassedSinceHit = 0f;

        if (isAxe)
        {
            newRed = 1f;
            newGreen = 0f;
            newBlue = 0f;
        } else
        {
            newRed = 0f;
            newGreen = 1f;
            newBlue = 0f;
        }
    }
}
