using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Destroy the bullet after 2 seconds
        Destroy(gameObject, 2);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Platform") {
            Destroy(gameObject);
        }

        if (other.tag == "Player" && gameObject.tag == "EnemyBullet") {
            FindObjectOfType<SessionController>().ReduceHealth(10);
        }
    }
    
}
