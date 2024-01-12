using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHealth : MonoBehaviour
{
    public float maxHP = 100;
    public float HP;

    public void Start()
    {
        HP = maxHP;
    }

    public void TakeDamage(int damageNun)
    {
        HP -= damageNun;

        if (HP <= 0)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("youLose");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hand"))
        {
            TakeDamage(10);
        }

        if (other.CompareTag("BOSS"))
        {
            TakeDamage(15);
        }

        if (other.gameObject.tag == "Trap")
        {
            HandlePlayerDeath();
        }

        if (other.CompareTag("Dasher"))
        {
            HandlePlayerDeath();
        }


    }
    private void HandlePlayerDeath()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("youLose");
    }
}
