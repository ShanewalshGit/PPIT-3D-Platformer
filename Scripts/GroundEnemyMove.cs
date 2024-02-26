using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GroundEnemyMove : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField] private float speed = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine("MoveEnemy");
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    IEnumerator MoveEnemy()
    {
        for (int i = 0; i < 1000; i++)
    {
        // Randomly choose a direction (-1 for left, 1 for right)
        int direction = Random.Range(0, 2) * 2 - 1; // This will generate either -1 or 1
        rb.velocity = new Vector2(speed * direction, rb.velocity.y);
        int randTime = Random.Range(1, 4);
        yield return new WaitForSeconds(randTime);
    }
    }
}
