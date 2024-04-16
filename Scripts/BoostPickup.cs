using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostPickup : MonoBehaviour
{
    //public float killZoneRadius = 5f; // The radius of the kill zone
    [SerializeField] public GameObject sparkEffect; // Assign this in the Inspector

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator OnTriggerEnter(Collider other)
    {
        
        // If the player picks up the ability, speed up the player for 5 seconds
        if (other.gameObject.CompareTag("Player"))
        {
            // Get the Player object from scene and Speed up the player
            FindAnyObjectByType<BaseMovement>().IncreaseSpeed(10f);

            // Wait for 5 seconds
            yield return new WaitForSeconds(5f);

            // Slow down the player
            other.GetComponent<BaseMovement>().sprintSpeed = 12f;

            // Destroy the ability pickup
            Destroy(gameObject);
        }
    }
}
