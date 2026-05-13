using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour {

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Attacker attacker = collision.GetComponent<Attacker>();
        Fox fox = collision.GetComponent<Fox>();

        if (attacker && !fox)
        {
            animator.SetTrigger("underAttack trigger");
        }
    }
}
