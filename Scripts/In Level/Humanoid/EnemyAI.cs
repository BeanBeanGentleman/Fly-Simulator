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
        Patroling();
        //if (!playerInSightRange && !playerInAttackRange) Patroling();
        //if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        //if (playerInAttackRange && playerInSightRange) AttackPlayer();
    }

    public bool is_in_sight_range()
    {
        return playerInSightRange;
    }


    private void Patroling()
    {
        anim.SetTrigger("Walk");
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
            dest_index = (dest_index + 1) % navPt.Length;
            in_transit = false;
        }
    }

    private void ChasePlayer()
    {
        anim.SetTrigger("Walk");
        anim.ResetTrigger("Attack");
        Vector3 dest = new Vector3(player.position.x, transform.position.y, player.position.z);
        agent.SetDestination(dest);
    }

    private void AttackPlayer()
    {
        //Make sure enemy doesn't move
        Vector3 targetPostition = new Vector3(player.position.x,
                                       transform.position.y,
                                       player.position.z);
        transform.LookAt(targetPostition);
        agent.SetDestination(transform.position);
        anim.ResetTrigger("Walk");
        if (!anim.GetBool("Attack"))
        {
            anim.SetTrigger("Attack");
        }
        else
        {
            int attack_type = Random.Range(0, 2);
            anim.SetInteger("Attack_type", attack_type);
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