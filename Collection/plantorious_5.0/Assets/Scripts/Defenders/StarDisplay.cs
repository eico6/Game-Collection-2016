using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(Text))]
public class StarDisplay : MonoBehaviour {

    private Text starCounter;

    public int totalStars = 100;
    public enum Status { SUCCESS, FAILURE };

    void Start () {
        starCounter = GetComponent<Text>();
        UpdateDisplay();
	}

    public void AddStars (int amount)
    {
        totalStars += amount;
        UpdateDisplay();
    }

    public Status UseStars(int amount)
    {
        if (totalStars >= amount)
        {
            totalStars -= amount;
            UpdateDisplay();
            return Status.SUCCESS;
        }
        return Status.FAILURE;
    }

    private void UpdateDisplay()
    {
        starCounter.text = totalStars.ToString();
    }
}
