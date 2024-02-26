using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostPlayer : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] public float speed;
    [SerializeField] public float boostForce;

    [SerializeField] private int maxBoost = 50000;

    // Notes - Decrease maxBoost and Increase boost force for bouncy style traversal

    //Notes - Increase maxBoost and Decrease boost force for long jump style traversal

    private float moveDirection;
    private int boostGauge;
    private bool canBoost;
    // Start is called before the first frame update
    void Start()
    {
        boostGauge = maxBoost;
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

        //long jump by holding space key
        if (Input.GetKey(KeyCode.Space) && canBoost)
        {
            rb.velocity = new Vector2(rb.velocity.x, boostForce);
            boostGauge++;
            Debug.Log("Boost= " + boostGauge);
        }

        //Limit jumps based on maxJumps
        if (boostGauge >= maxBoost)
        {
            canBoost = false;
            Debug.Log("Boost depleted!");
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
            boostGauge = 0;
            canBoost = true;
            Debug.Log("Boost recharged!");
        }
    }
        
}
