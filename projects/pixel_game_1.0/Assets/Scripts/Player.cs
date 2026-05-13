using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [SerializeField] float runSpeed = 12.0f;
    [SerializeField] float jumpSpeed = 10.0f;
    [SerializeField] float climbSpeed = 8.0f;

    private float normalGravity;

    Rigidbody2D myRigidBody;
    Animator myAnimator;
    CapsuleCollider2D bodyCollider;
    BoxCollider2D feetCollider;

    void Start()
    {
        bodyCollider = GetComponent<CapsuleCollider2D>();
        feetCollider = GetComponent<BoxCollider2D>();
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();

        normalGravity = myRigidBody.gravityScale;
    }

    void Update()
    {
        Run();
        ClimbLadder();
        FlipSprite();
    }

    private void FixedUpdate() //sån eg forsto da så caller denne per frame uavhengig av fps. Altså performance har ikke noe å si på dette. Physics er lurt å ha inni då.
    {
        Jump(); //Visst eg tar denne inni vanlig update, hopper han super høgt fordi det er sån 2-3 frames han er i bakken, 
                //som vil si at force blir multiplisert med extra frames. Inni her så hopper han på første frame or sæmn
    }

    private void Run()
    {
        float controlThrow = CrossPlatformInputManager.GetAxis("Horizontal"); // value is between -1 to +1
        Vector2 playerVelocity = new Vector2(controlThrow*runSpeed, myRigidBody.velocity.y);
        myRigidBody.velocity = playerVelocity;

        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;
        myAnimator.SetBool("boolRunning", playerHasHorizontalSpeed);
    }

    private void ClimbLadder()
    {
        bool isTouchingLadder = bodyCollider.IsTouchingLayers(LayerMask.GetMask("Ladder"));

        if (isTouchingLadder)
        {
            myAnimator.SetBool("boolJumpDown", false);
            myAnimator.SetBool("boolJumpUp", false);
            myRigidBody.gravityScale = 0.0f;
            float controlThrow = CrossPlatformInputManager.GetAxis("Vertical"); // value is between -1 to +1. "Full speed to the left" and "Full speed to the right"
            Vector2 climbVelocity = new Vector2(myRigidBody.velocity.x, controlThrow * climbSpeed);
            myRigidBody.velocity = climbVelocity;

            bool playerHasVercialSpeed = Mathf.Abs(myRigidBody.velocity.y) > Mathf.Epsilon;
            myAnimator.SetBool("boolClimbing", playerHasVercialSpeed);
        }
        else
        {
            myRigidBody.gravityScale = normalGravity;
            myAnimator.SetBool("boolClimbing", false);
        }

    }

    private void Jump()
    {
        bool touchingGround = feetCollider.IsTouchingLayers(LayerMask.GetMask("Ground"));
        bool isTouchingLadder = bodyCollider.IsTouchingLayers(LayerMask.GetMask("Ladder"));
        bool jumpDown = myAnimator.GetBool("boolJumpDown");

        if (CrossPlatformInputManager.GetButton("Jump") && touchingGround && !isTouchingLadder)
        {
            Vector2 jumpVelocityToAdd = new Vector2(0f, jumpSpeed);
            myRigidBody.velocity += jumpVelocityToAdd;
            myAnimator.SetBool("boolJumpUp", true);
        }

        if (myRigidBody.velocity.y < 0 && !isTouchingLadder)
        {
            jumpDown = true;
            myAnimator.SetBool("boolJumpUp", false);
            myRigidBody.gravityScale = 1.0f;
            if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            {
                myRigidBody.gravityScale = 5.0f;
            }
        } else if (myRigidBody.velocity.y > 0 && !CrossPlatformInputManager.GetButton("Jump"))
        {
            myRigidBody.gravityScale = 1.2f;
        }

        if (myRigidBody.velocity.y == 0 && jumpDown == true)
        {
            jumpDown = false;
        }
    }

    private void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;
        if (playerHasHorizontalSpeed == true)
        {
            transform.localScale = new Vector2(Mathf.Sign(myRigidBody.velocity.x),transform.localScale.y);
        }
    }
}
