using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    public float health;

    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    public Transform[] navPt;
    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    //States
    private float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    bool in_transit = false;
    private int dest_index = 0;
    Animator anim;
    int dir;
    Rigidbody rig;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        rig = GetComponent<Rigidbody>();
        player = GameObject.Find("Fly").transform;
        agent = GetComponent<NavMeshAgent>();
        sightRange = 50;
        attackRange = 20;
        rig.freezeRotation = true;
    }

    private void Update()
    {
        Debug.Log(navPt[0].position);
        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
        if (!playerInAttackRange) Patroling();
        //if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInAttackRange) AttackPlayer();
    }

    public bool is_in_sight_range()
    {
        return playerInSightRange;
    }


    private void Patroling()
    {
        anim.ResetTrigger("attack");    
        anim.SetTrigger("walk");
        if (navPt.Length == 0)
        {
            return;
        }
        // Only Start WALKING
        Transform new_dst = navPt[dest_index];
        Vector3 dest = new Vector3(new_dst.position.x, transform.position.y, new_dst.position.z);

        Vector3 to_walk_pt = transform.position - dest;
        if (to_walk_pt.magnitude > 1f)
        {
            if (!in_transit)
            {
                agent.SetDestination(dest);
                in_transit = true;
            }
            else
            {
                return;
            }
        }
        else
        {
            if (dest_index == navPt.Length - 1)
            {
                // Walk Back
                dir = -1;
            }
            else if (dest_index == 0)
            {
                dir = 1;
            }
            dest_index = (dest_index + dir);
            in_transit = false;
        }
    }

    private void ChasePlayer()
    {
        anim.SetTrigger("walk");
        anim.ResetTrigger("attack");
        Vector3 dest = new Vector3(player.position.x, transform.position.y, player.position.z);
        agent.SetDestination(dest);
    }

    private void AttackPlayer()
    {
        in_transit = false;
        //Make sure enemy doesn't move
        Vector3 targetPostition = new Vector3(player.position.x,
                                       transform.position.y,
                                       player.position.z);
        transform.LookAt(targetPostition);
        agent.SetDestination(transform.position);
        anim.ResetTrigger("walk");
        if (!anim.GetBool("attack"))
        {
            anim.SetTrigger("attack");
        }
        if (!alreadyAttacked)
        {
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }
}