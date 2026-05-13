using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour {

    public float speed = 3.0f;

    private bool moveRight, moveLeft, moveUp, moveDown;

    void Start() {
        moveRight = true;
        transform.position = new Vector3(0, 0, 1);
    }

    private void disableAllMovement()
    {
        moveRight = false;
        moveLeft = false;
        moveUp = false;
        moveDown = false;
    }

    private void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void Update() {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            disableAllMovement();
            moveRight = true;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            disableAllMovement();
            moveLeft = true;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            disableAllMovement();
            moveUp = true;
        } if (Input.GetKey(KeyCode.DownArrow))
        {
            disableAllMovement();
            moveDown = true;
        }


            if (moveRight)
            {
                transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
            } else if (moveLeft) {
                transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
            } else if (moveUp) {
                transform.position += new Vector3(0, speed * Time.deltaTime, 0);
            } else if (moveDown) {
                transform.position += new Vector3(0, -speed * Time.deltaTime, 0);
            }


            if (transform.position.y <= -4.72f)
        {
            LoadNextLevel();
        } if (transform.position.y >= 4.72f)
        {
            LoadNextLevel();
        } if (transform.position.x <= -6.4f)
        {
            LoadNextLevel();
        } if (transform.position.x >= 6.4f)
        {
            LoadNextLevel();
        }
        }
    }

