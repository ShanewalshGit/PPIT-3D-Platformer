using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityPickup : MonoBehaviour
{
    //public float killZoneRadius = 5f; // The radius of the kill zone
    public LayerMask enemyLayer; // The layer that enemies are on
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
        
        // If the player picks up the ability
        if (other.gameObject.CompareTag("Player"))
        {
            // Get all enemies
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

            // Store the positions of the enemies
            Vector3[] enemyPositions = new Vector3[enemies.Length];
            for (int i = 0; i < enemies.Length; i++)
            {
                enemyPositions[i] = enemies[i].transform.position;
            }

            // Kill and destroy all enemies
            foreach (GameObject enemy in enemies)
            {
                enemy.GetComponent<EnemyCollide>().KillEnemy();
            }

            // Instantiate the spark effect at each enemy's position
            foreach (Vector3 position in enemyPositions)
            {
                GameObject sparkInstance = Instantiate(sparkEffect, position, Quaternion.identity);
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
