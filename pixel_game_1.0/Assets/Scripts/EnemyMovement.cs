using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Rigidbody2D myRigidBody;

    [SerializeField] float moveSpeed = 1f;

    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (IsFacingRIght())
        {
            myRigidBody.velocity = new Vector2(moveSpeed, 0);
        }
        else
        {
            myRigidBody.velocity = new Vector2(-moveSpeed, 0);
        }
    }

    bool IsFacingRIght()
    {
        return transform.localScale.x > 0;
    }

    private void OnTriggerExit2D(Collider2D collision) //kossen gir ditta mening? Det er jo ein wall som enter box collideren, ingenting som leave
                                                       // og visst da er noko så leave, så er da kvar box collider under enemien per tile
    {
        transform.localScale = new Vector2(-(Mathf.Sign(myRigidBody.velocity.x)), 1f);
    }
}
