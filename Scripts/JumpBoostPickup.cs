using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class JumpBoostPickup : MonoBehaviour
{
    // Jump boost pickup effect
    [SerializeField] private float jumpBoost = 20.0f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("JumpBoostPickup OnTriggerEnter2D");
        // If the player picks up the jump boost
        if (other.gameObject.name == "Mimic")
        {
            Debug.Log("JumpBoostPickup OnTriggerEnter2D Player");
            // Find BaseMovement script and increase jump force
            other.gameObject.GetComponent<PlayerControl>().jumpForce += jumpBoost;
            // Destroy the jump boost pickup
            Destroy(gameObject);
        }
    }
}
