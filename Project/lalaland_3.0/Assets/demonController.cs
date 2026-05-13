using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class demonController : MonoBehaviour {

    private GameObject player;
    public NavMeshAgent navMeshAgent;
    public Animation[] animations;
    private float instaTime;

    void Start () {
        player = GameObject.Find("FPSController");
        //new Vector3 playerPosition = Vector3(player.transform.position.x, player.transform.position.y, Quaternion.identity);
        animations = (Animation[])Animation.FindObjectsOfType(typeof(Animation));
        foreach (Animation a in animations)
        {
            a.wrapMode = WrapMode.Loop;
        }

        instaTime = Time.timeSinceLevelLoad;
    }

    private void Update()
    {
        float timeSinceInstantiate = Time.timeSinceLevelLoad - instaTime;
        if (timeSinceInstantiate >= 10)
        {
            navMeshAgent.speed = 30f;
        }
    }
}
