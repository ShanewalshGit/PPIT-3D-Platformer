using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillFloor : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) // If player collides with the kill floor, remove a life
        {
            FindAnyObjectByType<SessionController>().RemoveLife();
        }
    }
}
