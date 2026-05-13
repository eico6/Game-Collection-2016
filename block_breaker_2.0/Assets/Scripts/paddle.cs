using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paddle : MonoBehaviour {

    public bool autoPlay = false;

    private ball ball;

    private void Start()
    {
        ball = GameObject.FindObjectOfType<ball>();
    }

    private void Awake()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update () {
        if (autoPlay == false)
        {
            MoveWithMouse();
        } else
        {
            AutoPlay();
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            autoPlay = !autoPlay;
        }
    }

    void MoveWithMouse()
    {
        Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0f);

        float MousePosInBlocks = Input.mousePosition.x / Screen.width * 16;

        paddlePos.x = Mathf.Clamp(MousePosInBlocks, 1.1f, 14.898f);

        this.transform.position = paddlePos;

    }

    void AutoPlay()
    {
        Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0f);

        Vector3 ballPos = ball.transform.position;

        paddlePos.x = Mathf.Clamp(ballPos.x, 0.5f, 15.5f);

        this.transform.position = paddlePos;
    }
}
