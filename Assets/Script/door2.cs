using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door2 : MonoBehaviour
{
    public string nextScene;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var aliens = GameObject.FindGameObjectsWithTag("Dasher");

            if (aliens.Length == 0)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(nextScene);
            }

        }

    }
}