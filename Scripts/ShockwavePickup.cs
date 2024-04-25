using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityPickup : MonoBehaviour
{
    public LayerMask enemyLayer; // The layer that enemies are on
    [SerializeField] public GameObject sparkEffect; // Assign this in the Inspector

    private IEnumerator OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Player")) // If the player collides with the ability pickup, kill all enemies
        {
            // Get all enemies
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

            // Store the positions of the enemies
            Vector3[] enemyPositions = new Vector3[enemies.Length];
            for (int i = 0; i < enemies.Length; i++) // Store the positions of the enemies
            {
                enemyPositions[i] = enemies[i].transform.position;
            }

            // Kill and destroy all enemies
            foreach (GameObject enemy in enemies) // Kill and destroy all enemies
            {
                enemy.GetComponent<EnemyCollide>().KillEnemy();
            }

            // Instantiate the spark effect at each enemy's position
            foreach (Vector3 position in enemyPositions) // Instantiate the spark effect at each enemy's position
            {
                GameObject sparkInstance = Instantiate(sparkEffect, position, Quaternion.identity);

                // Sound effect
                FindObjectOfType<AudioManager>().PlayExplosion();

                // wait for 0.2 seconds before destroying the spark effect
                yield return new WaitForSeconds(0.2f);
                // Destroy the spark effect
                Destroy(sparkInstance);
            }

            // Destroy the ability pickup
            Destroy(gameObject);
        }
    }
}
