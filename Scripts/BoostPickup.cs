using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostPickup : MonoBehaviour
{
    // Ability pickup effect
    [SerializeField] public GameObject sparkEffect;

    private IEnumerator OnTriggerEnter(Collider other)
    {
        
        // If the player picks up the ability, speed up the player for 5 seconds
        if (other.gameObject.CompareTag("Player"))
        {
            // Get the Player object from scene and Speed up the player
            FindAnyObjectByType<PlayerControl>().IncreaseSpeed(10f);

            // Wait for 5 seconds
            yield return new WaitForSeconds(5f);

            // Slow down the player
            other.GetComponent<PlayerControl>().sprintSpeed = 12f;

            // Destroy the ability pickup
            Destroy(gameObject);
        }
    }
}
