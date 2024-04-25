using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachinePart : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") // If player collides with the machine part, add a part to the player's inventory
        {
            //Debug.Log("Player has collided with machine part");
            // Play the part collected sound
            FindObjectOfType<AudioManager>().PlayPlayerCollect();
            FindAnyObjectByType<SessionController>().AddPart();
            Destroy(gameObject);
            
        }
    }
}
