using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class dasherHealth : MonoBehaviour
{
    public int bulletTouch;
    private Animator animator;
    private NavMeshAgent navMeshAgent; 
    public float time = 2.5f;

    private void Start()
    {
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            bulletTouch++;
            if (bulletTouch >= 3)
            {
                animator.SetBool("isDead", true);
                if (navMeshAgent != null)
                {
                    navMeshAgent.isStopped = true;
                }
                Invoke("DestroyGameObject", time);
            }
        }

    }
    public void DestroyGameObject()
    {
        Destroy(gameObject);
    }

}
