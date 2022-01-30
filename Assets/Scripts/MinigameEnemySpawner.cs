using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameEnemySpawner : MonoBehaviour
{
    public int spawnInterval = 3;

    void Start()
    {
        InvokeRepeating("SpawnEnemy", 0, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemy()
    {
        GameObject enemy = (GameObject) Resources.Load("MinigameEnemy");

        Instantiate(
            enemy,
            transform.position,
            Quaternion.identity
        );
    }
}
