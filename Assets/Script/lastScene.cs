using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lastScene : MonoBehaviour
{    
    void Update()
    {
        var aliens = GameObject.FindGameObjectsWithTag("Target");
        var boss = GameObject.FindGameObjectsWithTag("BOSS");

        if (aliens.Length == 0 && boss.Length == 0)
        {

            UnityEngine.SceneManagement.SceneManager.LoadScene("youWin");
        }

    }
}
