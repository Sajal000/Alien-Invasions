using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class alienNav : MonoBehaviour
{
    NavMeshAgent agent;
    GameObject player;
    private Animator animator;
    //public float attackRange = 2f;
    //bool inAttackRange; 
    private void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();
    }

    //private void OnDrawGizmos()
    //{
       // Gizmos.color = Color.red;
        //Gizmos.DrawWireSphere(transform.position, 10f);

        //Gizmos.color = Color.blue;
        //Gizmos.DrawWireSphere(transform.position, 45f);

        //Gizmos.color = Color.green;
        //Gizmos.DrawWireSphere(transform.position, 50f);
   // }
 
}
