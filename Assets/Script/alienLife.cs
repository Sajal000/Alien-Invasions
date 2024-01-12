using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class alienLife : MonoBehaviour
{
    public int bulletTouch;
    private Animator animator;
    private NavMeshAgent navMeshAgent;
    public float time = 3f; 

    private void Start()
    {
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            animator.SetTrigger("Damage");
            bulletTouch++;

            if (bulletTouch >= 3)
            {
                animator.SetTrigger("isDead");
                if (navMeshAgent != null)
                {
                    navMeshAgent.isStopped = true;
                }
                Invoke("Death", time);
            }
        }
    }

    public void Death()
    {
        Destroy(gameObject);
    }

}
