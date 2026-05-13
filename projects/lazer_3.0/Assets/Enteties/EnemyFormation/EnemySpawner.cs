using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject enemyPrefab;
    public float width = 10f;
    public float height = 5f;
    public int enemiesLeft = 0;

    [SerializeField] float speed = 3f;
    [SerializeField] float spawnDelay = 0.5f;

    private float Xmax;
    private float Xmin;
    private bool movingRight = false;



	void Start () {
        float distanceToCamera = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftEdge = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distanceToCamera));
        Vector3 rightEdge = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distanceToCamera));
        Xmax = rightEdge.x;
        Xmin = leftEdge.x;
        SpawnUntilFull();
    }


    void SpawnEnemies()
    {
        foreach (Transform child in transform)
        {
            GameObject enemy = Instantiate(enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;
            enemy.transform.parent = child;
            enemiesLeft++;
        }
    }


    public void SpawnUntilFull()
    {
        Transform freePosition = NextFreePosition();
        if (freePosition)
        {
            GameObject enemy = Instantiate(enemyPrefab, freePosition.position, Quaternion.identity) as GameObject;
            enemy.transform.parent = freePosition;
            enemiesLeft++;
        }
        if (NextFreePosition())
        {
            Invoke("SpawnUntilFull", spawnDelay);
        }
    }



    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position + new Vector3(0, 1), new Vector3(width, height));
    }


    void Update () {
        if (movingRight == true)
        {
            transform.position += new Vector3(speed*Time.deltaTime, 0);
          //transform.position += Vector3.right * speed * Time.deltaTime;
        }
        else
        {
            transform.position += new Vector3(-speed * Time.deltaTime, 0);
        }

        float leftBoundary = transform.position.x - (0.5f * width) + 0.47f;
        float rightBoundary = transform.position.x + (0.5f * width - 0.47f);
        if (rightBoundary > Xmax)
        {
            movingRight = false;
        } else if (leftBoundary < Xmin)
        {
            movingRight = true;
        }

        //Debug.Log(enemiesLeft);

        //if (AllMembersDead()){
            //debug.Log("Empty Formation");
            //SpawnUntilFull();
        //}
    }

    Transform NextFreePosition()
    {
        foreach (Transform childPositionGameObject in transform)
        {
            if (childPositionGameObject.childCount == 0)
            {
                return childPositionGameObject;
            }
        }
        return null;
    }

    //bool AlleMembersDead(){

    //foreach (Transform childPositionGameObject in transform){
        //if (ChildPositionGameObject.childCount > 0){
            //return false;
          //}
        //}
      // return true;

    //}

}
