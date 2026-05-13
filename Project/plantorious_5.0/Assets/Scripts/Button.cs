using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//using MariusPackage;

public class Button : MonoBehaviour {

    public GameObject defenderPrefab;
    public static GameObject selectedDefender;

    private Button[] buttonArray;
    private Text costText;
    private int starCost;
    private StarDisplay starDisplay;



    //GameoObject obj = null;


    private int x;
    private int y;


    string text;


    public Button(int xIn, int yIn, string textIn)
    {
        print("Button creation process started");
        this.x = xIn;
        this.y = yIn;
        

        this.text = textIn;

        print("Button created");


    }

    public int pressed()
    {        
        return 2;
    }


    void Start () {
        x = pressed();

        this.pressed();








        buttonArray = GameObject.FindObjectsOfType<Button>();
        starDisplay = GameObject.FindObjectOfType<StarDisplay>();

        costText = GetComponentInChildren<Text>();
        if (!costText) {Debug.LogWarning (name + " has no cost -Eivind");}
        starCost = defenderPrefab.GetComponent<Defender>().starCost;

        costText.text = starCost.ToString();
    }

    private void OnMouseDown()
    {
        foreach (Button thisButton in buttonArray)
        {
            thisButton.GetComponent<SpriteRenderer>().color = Color.black;
        }
        GetComponent<SpriteRenderer>().color = Color.white;
        selectedDefender = defenderPrefab;
    }
}
