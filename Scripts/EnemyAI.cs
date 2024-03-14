using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform player;
    public NavMeshAgent agent;
    public LayerMask whatIsGround, whatIsPlayer;

    //Projectile fire
    public Bullet bulletPrefab;
    public Transform bulletSpawn;
    public float bulletSpeed = 30.0f;
    public Coroutine fireCoroutine;

    public float health = 50;

    //Patrolling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    // Update is called once per frame
    private void Awake()
    {
        player = GameObject.Find("Mimic").transform;
        //Debug.Log("Player found");
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        //Debug.Log("Player in sight range: " + playerInSightRange);
        //Debug.Log("Player in attack range: " + playerInAttackRange);

        //If not in sight or attack range, patrolling, if in sight but not attack range, chase player, if in sight and attack range, attack player
        if (!playerInSightRange && !playerInAttackRange) Patrolling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInSightRange && playerInAttackRange) AttackPlayer();
    }

    private void Patrolling() {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet) agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint; // Distance between enemy and walkpoint

        //When walkpoint is reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }

    // Search for random point in range and set it as walkpoint
    private void SearchWalkPoint() {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        // Set walkpoint to random point in range and check if it is on the ground
        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    private void ChasePlayer() {
        //Debug.Log("Chasing Player");
        agent.SetDestination(player.position);
    }

    private void AttackPlayer() {
        agent.SetDestination(transform.position);

        transform.LookAt(player);

        if (!alreadyAttacked) {

            // Attack code

            // instantiate bullet
            Bullet bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            // give it position close to enemy
            bullet.transform.position = transform.position + new Vector3(1, 0, 0);
            // give it velocity in direction of player
            Rigidbody rbb = bullet.GetComponent<Rigidbody>();
            rbb.velocity = (player.position - transform.position).normalized * bulletSpeed;

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
            
            //Debug.Log("Attacking Player");
        }
    }

    private void ResetAttack() {
        alreadyAttacked = false;
    }

    public void TakeDamage(float damage) {
        health -= damage;

        if (health <= 0) Invoke(nameof(DestroyEnemy), 0.5f);
    }

    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
