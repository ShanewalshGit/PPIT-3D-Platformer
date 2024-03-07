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
            Destroy(other.gameObject);
            var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex);
            FindAnyObjectByType<SessionController>().RemoveLife();
        }
    }

    private void OnTriggerEnter(Collider other) {
        {
            Destroy(gameObject);

            var bullet = other.gameObject.GetComponent<Bullet>();
            if (bullet)
            {
                Destroy(bullet.gameObject);
                FindAnyObjectByType<SessionController>().AddPoints(10);
            }
        }
    }
}
