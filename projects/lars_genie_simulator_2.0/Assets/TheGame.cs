using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class TheGame : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public GameObject question, confirm, realText;
    public VideoClip idle_state, larsen, hell_yeah, I_dont_like_question, yeahhh, not_gonna_answer, that_is_not_question;

    private bool readyToChange, not_idle;
    private float TheGenieNumber;
    private Text questionText, confirmText;
    private InputField realTexten;
    private List<string> foo;
    private Animator confirmAnimator;

    void Start()
    {
        foo = new List<string>(12);
        foo.Add("What");foo.Add("what");foo.Add("Where");foo.Add("where");foo.Add("Who");foo.Add("who");
        foo.Add("When");foo.Add("when");foo.Add("Why");foo.Add("why");foo.Add("How");foo.Add("how");

        questionText = question.GetComponent<Text>();
        confirmText = confirm.GetComponent<Text>();
        realTexten = realText.GetComponent<InputField>();
        confirmAnimator = confirm.GetComponent<Animator>();
    }

    void Update()
    {
        if (videoPlayer.clip.name == "larsen" || videoPlayer.clip.name == "hell_yeah" || videoPlayer.clip.name == "I_dont_like_question" || 
            videoPlayer.clip.name == "yeahhh" || videoPlayer.clip.name == "not_gonna_answer" || videoPlayer.clip.name == "that_is_not_question")
        {
            not_idle = true;
        }

        if (Input.GetKeyDown(KeyCode.Return) && not_idle == false)
        {
            updateConfirm();
            clearQuestion();
            playAnswer();
        }

        if (not_idle == true && readyToChange && videoPlayer.isPlaying == false)
        {
            videoPlayer.clip = idle_state;
            videoPlayer.isLooping = true;
            readyToChange = false;
            not_idle = false;
        }
    }

    public void playAnswer()
    {
        TheGenieNumber = Random.Range(0.0f, 1.0f);
        bool listApproved = true;

        for (int i = 0; i < foo.Count; i++)
        {
            if (confirmText.text.Contains(foo[i])) listApproved = false;
        }

        if (!confirmText.text.Contains("?") || confirmText.text == "?")
        {
            print("Er ikkje eit spørsmål");
            if (TheGenieNumber >= 0.05f)
            {
                videoPlayer.clip = that_is_not_question;
            } else if (TheGenieNumber < 0.05f)
            {
                videoPlayer.clip = not_gonna_answer;
            }
            videoPlayer.Play();
            videoPlayer.isLooping = false;
            Invoke("PeppaPig", 1.7f);
            print(TheGenieNumber);
            confirmAnimator.SetTrigger("textPrompted");
            return;
        }

        if (!listApproved && confirmText.text.Contains("?"))
        {
            print("Journalistikk spørsmål");
            if (TheGenieNumber >= 0.65f)
            {
                videoPlayer.clip = not_gonna_answer;
            }
            else if (TheGenieNumber < 0.65f)
            {
                videoPlayer.clip = I_dont_like_question;
            }
            videoPlayer.Play();
            videoPlayer.isLooping = false;
            Invoke("PeppaPig", 1.7f);
            print(TheGenieNumber);
            confirmAnimator.SetTrigger("textPrompted");
            return;
        }

        if (listApproved && confirmText.text.Contains("?"))
        {
            print("Ja/Nei spørsmål");
            if (TheGenieNumber >= 0.5f)
            {
                videoPlayer.clip = larsen;
            }
            else if (TheGenieNumber >= 0.3f && TheGenieNumber <= 0.5f)
            {
                videoPlayer.clip = hell_yeah;
            }
            else if (TheGenieNumber >= 0.0f && TheGenieNumber <= 0.3f)
            {
                videoPlayer.clip = yeahhh;
            }
            videoPlayer.Play();
            videoPlayer.isLooping = false;
            Invoke("PeppaPig", 1.7f);
            print(TheGenieNumber);
            confirmAnimator.SetTrigger("textPrompted");
            return;
        }
    }

    private void PeppaPig()
    {
        readyToChange = true;
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
