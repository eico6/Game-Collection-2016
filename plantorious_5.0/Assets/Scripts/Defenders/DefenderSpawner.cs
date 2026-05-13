using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    public Camera myCamera;

    private GameObject defenderParent;
    private StarDisplay starDisplay;

    private void Start()
    {
        defenderParent = GameObject.Find("Defenders");
        starDisplay = GameObject.FindObjectOfType<StarDisplay>();

        if (!defenderParent)
        {
            defenderParent = new GameObject("Defenders");
        }
    }

    private void OnMouseDown()
    {
        if (!WinButton.isRoundOver)
        {
            Vector2 rawPos = CalculateWorldPointOfMouseClick();
            Vector2 roundedPos = SnapToGrid(rawPos);
            GameObject defender = Button.selectedDefender;

            if (defender)
            {
                int defenderCost = 0; 
                defenderCost = defender.GetComponent<Defender>().starCost;

                if (starDisplay.UseStars(defenderCost) == StarDisplay.Status.SUCCESS)
                {
                    SpawnDefender(roundedPos, defender);
                } else
                {
                    print("Not enough stars");
                }
            }
        }
    }

    private void SpawnDefender(Vector2 roundedPos, GameObject defender)
    {
        GameObject newDef = Instantiate(defender, roundedPos, Quaternion.identity) as GameObject;
        newDef.transform.parent = defenderParent.transform;
    }

    Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
        int newX = Mathf.RoundToInt(rawWorldPos.x);
        int newY = Mathf.RoundToInt(rawWorldPos.y);

        return new Vector2(newX, newY);
    }

    Vector2 CalculateWorldPointOfMouseClick()
    {
        float mouseX = Input.mousePosition.x;
        float mouseY = Input.mousePosition.y;
        //print(Input.mousePosition) printer kor i game du trykker, nede til venstre = (0, 0) og oppe til høgre i fullscreen = (1920, 1080).
        //Visst ikkje fullscreen, men bare i unity og tester uten Maximize on Play, viser oppe til høgre sån sirka (900, 600). Størrelsen av game window in pixels.
        float distanceFromCamera = 10f;

        Vector3 weirdTriplet = new Vector3(mouseX, mouseY, distanceFromCamera);
        Vector2 worldPos = myCamera.ScreenToWorldPoint(weirdTriplet);
        //ScreenToWorldPoint er bare op, bare tenk at den trenger Vector3 og er op

        return worldPos;
    }
}
