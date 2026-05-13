using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class NumberWizard : MonoBehaviour {

    int max;
    int min;
    int guess;

    public int MaxGuessesAllowed = 11;
    public Text text;
    public Text Guesses_Left;
    public Text correct;

    void Start () {
        StartGame();
	}
	
    void StartGame ()
    {
        max = 1000;
        min = 1;
        NextGuess();
        max = max + 1;
    }

    public void GuessHigher()
    {
        min = guess;
        NextGuess();
    }

    public void GuessLower()
    {
        max = guess;
        NextGuess();
    }


        void NextGuess ()
        {
        guess = Random.Range(min, max);
        text.text = guess.ToString();
            MaxGuessesAllowed = MaxGuessesAllowed - 1;
        if (MaxGuessesAllowed < 0)
        {
            Application.LoadLevel("Win");
            MaxGuessesAllowed = MaxGuessesAllowed + 1;
            text.text = guess.ToString();
        }
        if (MaxGuessesAllowed == 0)
        {
            correct.text = ("Correct!");
        }
        Guesses_Left.text = "Guesses left: "+MaxGuessesAllowed.ToString();
        }

	}

    

