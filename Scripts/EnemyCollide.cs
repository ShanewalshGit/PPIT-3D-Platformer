using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.SceneManagement;

public class EnemyCollide : MonoBehaviour
{
    Rigidbody rb;

    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            FindAnyObjectByType<SessionController>().ReduceHealth(10);
        }

        if (other.gameObject.tag == "Bullet" || other.gameObject.tag == "Cannonball")
        {
            Debug.Log("Bullet hit enemy");
            Destroy(gameObject);
            Destroy(other.gameObject);
            FindAnyObjectByType<SessionController>().AddHealth(10);

            // Death sfx
            FindObjectOfType<AudioManager>().PlayEnemyDeath();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            FindAnyObjectByType<SessionController>().ReduceHealth(10);
        }

        if (other.gameObject.tag == "Bullet" || other.gameObject.tag == "Cannonball")
        {
            Debug.Log("Bullet hit enemy");
            Destroy(gameObject);
            Destroy(other.gameObject);
            FindAnyObjectByType<SessionController>().AddHealth(10);

            // Death sfx
            FindObjectOfType<AudioManager>().PlayEnemyDeath();
        }
    }

    public void KillEnemy()
    {
        Destroy(gameObject);
        FindAnyObjectByType<SessionController>().AddHealth(10);
    }
}
