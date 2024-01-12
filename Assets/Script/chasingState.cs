using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class chasingState : StateMachineBehaviour
{
    Transform player;
    NavMeshAgent agent;

    public float chaseSpeed = 6f;
    public float stopDistance = 21;
    public float attackDistance = 2.5f;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateinfo, int layerindex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = animator.GetComponent<NavMeshAgent>();

        agent.speed = chaseSpeed;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateinfo, int layerindex)
    {
        agent.SetDestination(player.position);
        animator.transform.LookAt(player);

        float distanceFromPlayer = Vector3.Distance(player.position, animator.transform.position);

        if(distanceFromPlayer > stopDistance)
        {
            animator.SetBool("isChasing",false);
        }

        if(distanceFromPlayer < attackDistance)
        {
            animator.SetBool("isAttacking", true);
        }

    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateinfo, int layerindex)
    {
        agent.SetDestination(animator.transform.position);
    }
}
