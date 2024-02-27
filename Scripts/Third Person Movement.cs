using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    [Header("References")]
    public Transform orientDirection;
    [SerializeField] public Transform player;
    [SerializeField] public Transform playerObj;
    public Rigidbody rb;

    [SerializeField] public float rotationSpeed;


private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void Update()
    {
        Vector3 viewDir = player.position - new Vector3(transform.position.x, player.position.y, transform.position.z);
        orientDirection.forward = viewDir.normalized;

        // rotate palyer object
        float Horizontal = Input.GetAxis("Horizontal");
        float Vertical = Input.GetAxis("Vertical");
        Vector3 direction = orientDirection.forward * Vertical + orientDirection.right * Horizontal;

        if(direction != Vector3.zero)
        {
            playerObj.forward = Vector3.Slerp(playerObj.forward, direction.normalized, Time.deltaTime * rotationSpeed);
        }
    }
}
