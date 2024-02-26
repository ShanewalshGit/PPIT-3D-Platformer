using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlternativeMove : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] public float speed;
    [SerializeField] public float jumpForce;
    [SerializeField] private int maxJumps = 4;

    private float moveDirection;
    private int jumpGauge;
    private bool canJump;


    // Start is called before the first frame update
    void Start()
    {
        jumpGauge = maxJumps;
        rb = GetComponent<Rigidbody2D>();    
    }

    // Update is called once per frame
    void Update()
    {
        // Movement with arrow keys and or wasd
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        // Jumping with space key
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpGauge++;
            Debug.Log("Jump= " + jumpGauge);
        }

        //Limit jumps based on maxJumps
        if (jumpGauge >= maxJumps)
        {
            canJump = false;
        }

        // Flip the player sprite
        if (moveDirection > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (moveDirection < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        // camera follow player
        Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, Camera.main.transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Ground"))
        {
            jumpGauge = 0;
            canJump = true;
        }
    }
}
