using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dasherNav : MonoBehaviour
{
    UnityEngine.AI.NavMeshAgent agent;
    GameObject player;
    private Animator animator; 
    private void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();
    }

    //void //Update()
    //{
        //agent.destination = player.transform.position;

    //}

    private void Update()
    {
        agent.destination = player.transform.position;
        if (agent.velocity.magnitude > 0.1f)
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
    }
}
