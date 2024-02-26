using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnControl : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private int maxEnemies = 5;
    [SerializeField] private float spawnTime = 3.0f;
    [SerializeField] private float spawnInterval = 3.0f;

    private int enemiesSpawned = 0;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SpawnEnemyWaves");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemyWaves()
    {
        InvokeRepeating("SpawnOneEnemy", spawnTime, spawnInterval);
    }

    void SpawnOneEnemy()
    {
        //Randomly select a spawn point from the array
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        //Instantiate the enemy at the selected spawn point
        Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        enemiesSpawned++;
        

        //If there are more than maxEnemies, stop spawning
        if(GameObject.FindGameObjectsWithTag("Enemy").Length >= maxEnemies)
        {
            CancelInvoke("SpawnOneEnemy");
        }
        
    }
}
