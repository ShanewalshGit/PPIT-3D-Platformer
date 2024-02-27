using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    public Transform orient;
    float horizontal;
    float vertical;

    public float jumpForce;
    public float jumpCooldownTime;
    public float airMultiplier;
    bool canJump;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;

    [Header("Ground Check")]
    public LayerMask groundLayer;
    public float playerHeight;
    public float groundDrag;
    bool isGrounded;

    Vector3 moveDir;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        canJump = true;
    }

    private void Update()
    {
        // Ground Check based on player height and ground mask layer
        //isGrounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, groundLayer); 
        //Debug.Log(groundLayer);
        //Debug.Log(isGrounded);

        InputHandler();
        LimitSpeed();

        /*
        if (isGrounded)
        {
            Debug.DrawRay(transform.position, Vector3.down * (playerHeight * 0.5f + 0.2f), Color.green);
        }
        else
        {
            Debug.DrawRay(transform.position, Vector3.down * (playerHeight * 0.5f + 0.2f), Color.red);
        }
        */

        // Handle drag
        if (isGrounded)
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = 0;
        }
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void InputHandler()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(jumpKey) && canJump)
        {
            canJump = false;
            Debug.Log("Jump");
            Jump();
            Invoke(nameof(ResetCanJump), jumpCooldownTime);
        }
    }

    private void Movement()
    {
        // calculate move direction
        moveDir = orient.forward * vertical + orient.right * horizontal;

        // on ground
        if(isGrounded)
        {
            rb.AddForce(10f * moveSpeed * moveDir.normalized, ForceMode.Force);
        }
        // if in air
        else if(!isGrounded)
        {
            rb.AddForce(10f * airMultiplier * moveSpeed * moveDir.normalized, ForceMode.Force);
        }

    }

    private void LimitSpeed()
    {
        Vector3 vel = new Vector3(rb.velocity.x, 0, rb.velocity.z);

        if(vel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = vel.normalized*moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void ResetCanJump(){
        canJump = true;
    }

    


}
