using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            LoadPastLevel();
        }
    }


    public void LoadPastLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }




}
