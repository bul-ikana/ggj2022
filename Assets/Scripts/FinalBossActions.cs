using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBossActions : EnemyActions
{
    Transform shootPoint1;
    Transform shootPoint2;
    Transform shootPoint3;
    Transform shootPoint4;
    Transform shootPoint5;
    Transform shootPoint6;
    Transform shootPoint7;
    Transform shootPoint8;

    protected override void Start()
    {
        base.Start();

        shootPoint1 = GameObject.Find("ShootPoint1").transform;
        shootPoint2 = GameObject.Find("ShootPoint2").transform;
        shootPoint3 = GameObject.Find("ShootPoint3").transform;
        shootPoint4 = GameObject.Find("ShootPoint4").transform;
        shootPoint5 = GameObject.Find("ShootPoint5").transform;
        shootPoint6 = GameObject.Find("ShootPoint6").transform;
        shootPoint7 = GameObject.Find("ShootPoint7").transform;
        shootPoint8 = GameObject.Find("ShootPoint8").transform;

        InvokeRepeating("ShootDiagonal", 2f, 2f);
        InvokeRepeating("ShootStraight", 1f, 2f);
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

    void ShootDiagonal()
    {
        Instantiate(Resources.Load("EnemyBulletPrefab"), shootPoint1.position, shootPoint1.rotation);
        Instantiate(Resources.Load("EnemyBulletPrefab"), shootPoint2.position, shootPoint2.rotation);
        Instantiate(Resources.Load("EnemyBulletPrefab"), shootPoint3.position, shootPoint3.rotation);
        Instantiate(Resources.Load("EnemyBulletPrefab"), shootPoint4.position, shootPoint4.rotation);
    }

    void ShootStraight()
    {
        Instantiate(Resources.Load("EnemyBulletPrefab"), shootPoint5.position, shootPoint5.rotation);
        Instantiate(Resources.Load("EnemyBulletPrefab"), shootPoint6.position, shootPoint6.rotation);
        Instantiate(Resources.Load("EnemyBulletPrefab"), shootPoint7.position, shootPoint7.rotation);
        Instantiate(Resources.Load("EnemyBulletPrefab"), shootPoint8.position, shootPoint8.rotation);
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

    protected override void Die()
    {
        Instantiate(Resources.Load("DestroyedBoss"), transform.position, transform.rotation);

        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        MechaActions mecha = collision.collider.GetComponent<MechaActions>();

        if (mecha != null)
        {
            mecha.Damage(damage);
        }
    }
}
