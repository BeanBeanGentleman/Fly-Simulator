using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform goal;
    private NavMeshAgent agent;
    private bool playerInSightRange;
    private bool playerInAttackRange;
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void FixedUpdate()
    {
        ChasePlayer();
    }

    private void ChasePlayer()
    {
        Vector3 target_pos = new Vector3(goal.position.x, transform.position.y, goal.position.z);
        Debug.Log(agent.SetDestination(target_pos));
    }
}
