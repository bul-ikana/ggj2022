using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    GameObject mecha;

    void Start()
    {
        mecha = GameObject.Find("Mecha");
        InvokeRepeating("SpawnEnemy", 0, 2.5f);
    }

    void SpawnEnemy()
    {
        Instantiate(
            Resources.Load("EnemyPrefab"),
            (Vector3)Random.insideUnitCircle.normalized * Random.Range(10, 20) + mecha.transform.position,
            Quaternion.identity
        );
    }
}
