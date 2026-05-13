using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TheTextGame : MonoBehaviour
{
    public GameObject question, confirm, realText;

    private Text questionText, confirmText;
    private InputField realTexten;

    void Start()
    {
        questionText = question.GetComponent<Text>();
        confirmText = confirm.GetComponent<Text>();
        realTexten = realText.GetComponent<InputField>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            updateConfirm();
            clearQuestion();
        }
    }

    private void updateConfirm()
    {
        confirmText.text = questionText.text;
    }

    private void clearQuestion()
    {
        realTexten.text = "";
    }
}
