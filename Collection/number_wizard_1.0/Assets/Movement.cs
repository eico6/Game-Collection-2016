using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    private Vector3 input;
    Rigidbody cubeMovement;
    private float maxSpeed = 5f;
    // Use this for initialization
    void Start()
    {
        cubeMovement = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        if (cubeMovement.velocity.magnitude < maxSpeed)
        {
            cubeMovement.AddForce(input * moveSpeed);
        }

        if (Input.GetKey(KeyCode.A))
        {
            cubeMovement.AddForce(input * moveSpeed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            cubeMovement.AddForce(input * moveSpeed);
        }

        if (Input.GetKey(KeyCode.W))
        {
            cubeMovement.AddForce(input * moveSpeed);
        }

        if (Input.GetKey(KeyCode.S))
        {
            cubeMovement.AddForce(input * moveSpeed);
        }
    }
}