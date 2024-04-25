using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GroundEnemyMove : MonoBehaviour
{
    Rigidbody rb;

    [SerializeField] private float speed = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine("MoveEnemy");
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    IEnumerator MoveEnemy()
    {
        // for (int i = 0; i < 1000; i++)
        // {
        //     // Randomly choose a direction (-1 for left, 1 for right)
        //     int directionX = Random.Range(0, 2) * 2 - 1; // This will generate either -1 or 1
        //     int directionZ = Random.Range(0, 2) * 2 - 1; // This will generate either -1 or 1

        //     rb.velocity = new Vector3(speed * directionX, rb.velocity.y, speed * directionZ);
        //     int randTime = Random.Range(1, 4);
        //     yield return new WaitForSeconds(randTime);
        // }

        // Chase the player
        while (true)
        {
            GameObject player = GameObject.FindWithTag("Player");
            if (player != null)
            {
                Vector3 direction = (player.transform.position - transform.position).normalized;
                rb.velocity = new Vector3(direction.x * speed, rb.velocity.y, direction.z * speed);
            }
            yield return new WaitForSeconds(0.5f);
        }
    }
}
