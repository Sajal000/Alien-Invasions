using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossHealth : MonoBehaviour
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
            animator.SetTrigger("isHit");
            if (bulletTouch >= 15)
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
