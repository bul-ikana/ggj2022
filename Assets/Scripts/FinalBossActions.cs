using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBossActions : EnemyActions
{
    Transform shootPoint1;
    Transform shootPoint2;
    Transform shootPoint3;
    Transform shootPoint4;

    protected override void Start()
    {
        base.Start();

        shootPoint1 = GameObject.Find("ShootPoint1").transform;
        shootPoint2 = GameObject.Find("ShootPoint2").transform;
        shootPoint3 = GameObject.Find("ShootPoint3").transform;
        shootPoint4 = GameObject.Find("ShootPoint4").transform;

        InvokeRepeating("Shoot", 1f, 1f);
        InvokeRepeating("Attack", 5f, 5f);
    }
       
    void Update()
    {
        MoveTowardsMecha();
        Rotate();
    }

    void Rotate()
    {
        transform.Rotate(Vector3.forward * Time.deltaTime * speed * 10);
    }

    void Shoot()
    {
        Instantiate(Resources.Load("EnemyBulletPrefab"), shootPoint1.position, shootPoint1.rotation);
        Instantiate(Resources.Load("EnemyBulletPrefab"), shootPoint2.position, shootPoint2.rotation);
        Instantiate(Resources.Load("EnemyBulletPrefab"), shootPoint3.position, shootPoint3.rotation);
        Instantiate(Resources.Load("EnemyBulletPrefab"), shootPoint4.position, shootPoint4.rotation);
    }

    void Attack()
    {
        int pattern = Random.Range(1,4);

        switch(pattern)
        {
            case 1:
                break;
            case 2:
                CreateRockBarrier();
                break;
            case 3:
                break;
            case 4:
                break;
        }
    }

    void CreateRockBarrier()
    {
        Vector3 spawnPosition = GameObject.Find("BackSpawnPoint").transform.position;
        Instantiate(Resources.Load("StoneWallPrefab"), spawnPosition, mecha.transform.rotation);
    }
}
