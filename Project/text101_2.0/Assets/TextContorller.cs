using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class TextContorller : MonoBehaviour
{

    public Text text;

    private enum States { cell, mirror, sheets_0, lock_0, cell_mirror, sheets_1, lock_1, corridor_0, corridor_1,
                          corridor_2, corridor_3, window_0, window_1, window_2, floor, closet_door, in_closet, courtyard, GoForIt, Bad_Idea};

    private States myState;

    // Use this for initialization
    void Start()
    {
        myState = States.cell;
    }

    // Update is called once per frame
    void Update()
    {
        {
            print(myState);
            if (myState == States.cell)                  { state_cell(); }
            else if (myState == States.sheets_0)         { state_sheets_0(); }
            else if (myState == States.sheets_1)         { state_sheets_1(); }
            else if (myState == States.lock_0)           { state_lock_0(); }
            else if (myState == States.lock_1)           { state_lock_1(); }
            else if (myState == States.mirror)           { state_mirror(); }
            else if (myState == States.cell_mirror)      { state_cell_mirror(); }
            else if (myState == States.corridor_0)       { state_corridor_0(); }
            else if (myState == States.corridor_1)       { state_corridor_1(); }
            else if (myState == States.corridor_2)       { state_corridor_2(); }
            else if (myState == States.corridor_3)       { state_corridor_3(); }
            else if (myState == States.floor)            { state_floor(); }
            else if (myState == States.window_0)         { state_window_0(); }
            else if (myState == States.window_1)         { state_window_1(); }
            else if (myState == States.window_2)         { state_window_2(); }
            else if (myState == States.closet_door)      { state_closet_door(); }
            else if (myState == States.in_closet)        { state_in_closet(); }
            else if (myState == States.courtyard)        { state_courtyard(); }
            else if (myState == States.GoForIt)          { state_GoForIt(); }
            else if (myState == States.Bad_Idea)          { state_Bad_Idea(); }
        }
    }

    void state_cell()
    {
        text.text = "You are in a prison cell, and you want to escape. There are " +
                    "some dirty sheets on the bed, a mirror on the wall, and the door " +
                    "is locked from the outside. \n\n" +
                    "Press S to view Sheets, M to view Mirror and L to view Lock";
        if (Input.GetKeyDown(KeyCode.S))
        {
            myState = States.sheets_0;
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            myState = States.lock_0;
        }
        else if (Input.GetKeyDown(KeyCode.M))
        {
            myState = States.mirror;
        }
    }

    void state_mirror()
    {
        text.text = "The mirror is loose, seems easy to grab that shi. \n\n" +
                    "Press T to grab the mirror, R to return to roaming your cell";
        if (Input.GetKeyDown(KeyCode.R))
        {
            myState = States.cell;
        }
        else if (Input.GetKeyDown(KeyCode.T))
        {
            myState = States.cell_mirror;
        }
    }

    void state_sheets_0()
    {
        text.text = "You slept in that. It's lika so nasty!" +
                    " There are nothing more to see. \n\n" +
                    "Press R to return to roaming your cell";
        if (Input.GetKeyDown(KeyCode.R))
        {
            myState = States.cell;
        }
    }

    void state_sheets_1()
    {
        text.text = "Holding the mirror doesn't make the sheets look any better... stopid. \n\n" +
                    "Press R to return to roaming your cell";
        if (Input.GetKeyDown(KeyCode.R))
        {
            myState = States.cell_mirror;
        }
    }

    void state_lock_0()
    {
        text.text = "This is a lock with a combination code. You are thinkhing: " +
                    "shiii boi, I whish I knew what it was! \n\n" +
                    "Press R to return to roaming your cell";
        if (Input.GetKeyDown(KeyCode.R))
        {
            myState = States.cell;
        }
    }

    void state_lock_1()
    {
        text.text = "You put the mirror through the bars and turn it so you " +
                    "can see the lock. You can make out the fingerprints around " +
                    "the buttons. You press them, and hear a click. \n\n" +
                    "Press O to Open, or R to Return to your cell";
        if (Input.GetKeyDown(KeyCode.R))
        {
            myState = States.cell_mirror;
        }
        else if (Input.GetKeyDown(KeyCode.O))
        {
            myState = States.corridor_0;
        }

    }
    
    void state_cell_mirror()
    {
        text.text = "You got that mirror in your hands my man, but what now? \n\n" +
                    "Press S to view sheets, L to view Lock";
        if (Input.GetKeyDown(KeyCode.S))
        {
            myState = States.sheets_1;
        } else if (Input.GetKeyDown(KeyCode.L))
        {
            myState = States.lock_1;
        }
    }

    void state_corridor_0()
    {
        text.text = "You open the door and step into the corridor. You see stairs, " +
                    "something on the floor and a closet. \n\n" + 
                    "Press W to view stairs, F to view floor and C to view closet";
        if (Input.GetKeyDown(KeyCode.W))
        {
            myState = States.window_0;
        } else if (Input.GetKeyDown(KeyCode.F))
        {
            myState = States.floor;
        } else if (Input.GetKeyDown(KeyCode.C))
        {
            myState = States.closet_door;
        }

    }

    void state_closet_door()
    {
        text.text = "Closet is locked. I better get back before they see me. \n\n" +
                    "Press R to return to the corridor";
        if (Input.GetKeyDown(KeyCode.R))
        {
            myState = States.corridor_0;
        }
    }

    void state_window_0()
    {
        text.text = "You go down the stairs and see a courtyard with a lot of guards. Maybe it's best to turn back. \n\n " +
                    "Press R to return to the corridor or G to go for it";
        if (Input.GetKeyDown(KeyCode.R))
        {
            myState = States.corridor_0;
        } else if (Input.GetKeyDown(KeyCode.G))
        {
            myState = States.GoForIt;
        } 
    }

    void state_floor()
    {
        text.text = "You take a closer look at what the object on the floor is. " +
                    "It's a hairclip. Maybe it can be usefull? \n\n" +
                    "Press P to pick it up or R to return";
        if (Input.GetKeyDown(KeyCode.R))
        {
            myState = States.corridor_0;
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            myState = States.corridor_1;
        }

    }

    void state_corridor_1()
    {
        text.text = "You picked it up and are wondering what you should do next. \n\n" +
                    "Press W to view stairs or C to view closet";
        if (Input.GetKeyDown(KeyCode.W))
        {
            myState = States.window_1;
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            myState = States.in_closet;
        }

    }

    void state_window_1()
    {
        text.text = "The hairclip can't do anything usefull here, but maybe the guards won't notice you if you try to sneak past them. \n\n" +
                    "Press R to return to the corridor or S to sneak past them";
        if (Input.GetKeyDown(KeyCode.R))
        {
            myState = States.corridor_1;
        } else if (Input.GetKeyDown(KeyCode.S))
        {
            myState = States.GoForIt;
        }
    }

    void state_in_closet()
    {
        text.text = "You managed to open the closet with the hairclip. Inside, you " +
                    "find uniforms. You come up with a crazy idea: what if I dress up as one of the guards? \n\n" +
                    "Press D to dress up or R to return to the corridor";
        if (Input.GetKeyDown(KeyCode.R))
        {
            myState = States.corridor_2;
        } else if (Input.GetKeyDown(KeyCode.D))
        {
            myState = States.corridor_3;
        }
    }

    void state_GoForIt()
    {
        text.text = "They immediately notice you and fires at you. \nYou DIED. \n\n" +
                    "Press R to Restart";
        if (Input.GetKeyDown(KeyCode.R))
        {
            myState = States.cell;
        }
    }

    void state_corridor_2()
    {
        text.text = "You are back at the corridor. Should I go down the stairs? \n\n" +
                    "Press C to view closet again or S to go down the stairs";
        if (Input.GetKeyDown(KeyCode.C))
        {
            myState = States.in_closet;
        } else if (Input.GetKeyDown(KeyCode.S))
        {
            myState = States.window_2;
        }
    }

    void state_window_2()
    {
        text.text = "You see the guards outside. Even after opening the closet, you don't feel like going out there is a good idea. \n\n" +
                    "Press R to return to the corridor or S to sneak past them";
        if (Input.GetKeyDown(KeyCode.R))
        {
            myState = States.corridor_2;
        } else if (Input.GetKeyDown(KeyCode.S))
        {
            myState = States.GoForIt;
        }
    }

    void state_corridor_3()
    {
        text.text = "You are all dressed up and the uniform fits like a charm, but is this really a good idea? \n\n" +
                    "Press U to undress and put it back in the closet or E to try to escape";
        if (Input.GetKeyDown(KeyCode.U))
        {
            myState = States.Bad_Idea;
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            myState = States.courtyard;
        }
    }

    void state_Bad_Idea()
    {
        text.text = "What was I thinking? Better find another solution. \n\n" +
                    "Press D to Dress up again or S to view stairs";
        if (Input.GetKeyDown(KeyCode.D))
        {
            myState = States.corridor_3;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            myState = States.window_2;
        }
    }

    void state_courtyard()
    {
        text.text = "CONGRATULATIONS! You escaped! The guards thought you were one of them! \n\n" +
                    "Press P to play again";
        if (Input.GetKeyDown(KeyCode.P))
        {
            myState = States.cell;
        }
    }
}
