using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    // Camera variables
    [Header("References")]
    public Transform orientDirection;
    [SerializeField] public Transform player;
    [SerializeField] public Transform playerObj;
    public Rigidbody rb;

    [SerializeField] public float rotationSpeed;

    // Camera styles
    public CamStyle styleInUse;
    public Transform shooterLookAt;

    // Cinemachine camera objects
    public GameObject thirdPersonCam;
    public GameObject topDownCam;
    public GameObject shooterCam;

    public enum CamStyle // Camera styles to be used in the game
    {
        Basic,
        Shooter,
        TopDown
    }


private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void Update()
    {
        // Switch camera style based on key press
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwitchCam(CamStyle.Basic);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SwitchCam(CamStyle.Shooter);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SwitchCam(CamStyle.TopDown);
        }

        // Rotate player object based on camera view
        Vector3 viewDir = player.position - new Vector3(transform.position.x, player.position.y, transform.position.z);
        orientDirection.forward = viewDir.normalized;

        // rotate player object based on camera style in use
        if (styleInUse == CamStyle.Basic || styleInUse == CamStyle.TopDown)
        {
            float Horizontal = Input.GetAxis("Horizontal");
            float Vertical = Input.GetAxis("Vertical");
            Vector3 direction = orientDirection.forward * Vertical + orientDirection.right * Horizontal;

            if(direction != Vector3.zero)
            {
                playerObj.forward = Vector3.Slerp(playerObj.forward, direction.normalized, Time.deltaTime * rotationSpeed); // Smoothly rotate player object
            }
        }
        else if (styleInUse == CamStyle.Shooter) // Rotate player object based on shooter camera view
        {
            Vector3 dirToShooterLookAtObj = shooterLookAt.position - new Vector3(transform.position.x, shooterLookAt.position.y, transform.position.z);
            orientDirection.forward = dirToShooterLookAtObj.normalized;

            playerObj.forward = orientDirection.forward;
        }
        
    }

    private void SwitchCam(CamStyle style)
    {
        // Disable all cameras
        shooterCam.SetActive(false);
        thirdPersonCam.SetActive(false);
        topDownCam.SetActive(false);

        // Enable the camera style in use based on key press
        if(style == CamStyle.Basic)
        {
            thirdPersonCam.SetActive(true);
        }
        else if(style == CamStyle.Shooter)
        {
            shooterCam.SetActive(true);
        }
        else if(style == CamStyle.TopDown)
        {
            topDownCam.SetActive(true);
        }

        styleInUse = style;
    }
}
