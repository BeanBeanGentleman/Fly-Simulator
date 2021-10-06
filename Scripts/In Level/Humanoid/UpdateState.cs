using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UpdateState : MonoBehaviour
{
    public Transform goal;
    private NavMeshAgent agent;
    private bool playerInSightRange;
    private bool playerInAttackRange;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        playerInAttackRange = false;
        playerInSightRange = true;
        agent.destination = goal.position;
    }

    private void Update()
    {
        if (!playerInSightRange && !playerInAttackRange)
        {
            Debug.Log("Partolling");
            Patroling();
        }
        else if (playerInSightRange && !playerInAttackRange)
        {
            Debug.Log("ChasePlayer");
            ChasePlayer();
        }
    }

    private void Patroling()
    {
        return;
    }

    private void ChasePlayer()
    {
        //agent.destination = goal.position;
    }
}
