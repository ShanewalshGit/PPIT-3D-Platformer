using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AirEnemyMove : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField] private float speed = 2.0f;
    private bool hitWall = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine("MoveAirEnemy");
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    IEnumerator MoveAirEnemy()
    {
        // Move the enemy in a looped path of left and right 100 times
        for (int i = 0; i < 1000; i++)
        {
            // If the enemy hits a wall, change the direction of the enemy
            if (hitWall)
            {
                speed = -speed;
                hitWall = false;
            }
            int direction = Random.Range(0, 2) * 2 - 1; // This will generate either -1 or 1
            rb.velocity = new Vector2(speed * direction, rb.velocity.y);
            int randTime = Random.Range(1, 4);
            yield return new WaitForSeconds(randTime);
            // change direction of the enemy
            speed = -speed;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            hitWall = true;
        }
    }
}
