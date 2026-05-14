using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thrust : MonoBehaviour
{

    private ParticleSystem part;


    // Use this for initialization
    void Start()
    {
        part = GetComponentInChildren<ParticleSystem>();
        var main = part.main;
        main.simulationSpace = ParticleSystemSimulationSpace.World;

        


        //var main = ps.main;
        //main.simulationSpace = ParticleSystemSimulationSpace.Custom;
        //main.customSimulationSpace = relativeTo;

    }

    void Update()
    {
        var emission = part.emission;

        if ((Input.GetKey(KeyCode.UpArrow)) || (Input.GetKey(KeyCode.DownArrow)) || (Input.GetKey(KeyCode.LeftArrow)) || (Input.GetKey(KeyCode.RightArrow)))
        {
            emission.rateOverTime = 240f;
        }
        else
        {
            emission.rateOverTime = 0f;

        }
        
    }
}




