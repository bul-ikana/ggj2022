using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneActions : MonoBehaviour
{
    public int health;
    public int damage;

    void OnCollisionEnter2D(Collision2D collision)
    {
        BulletActions bullet = collision.collider.GetComponent<BulletActions>();
        if (bullet != null) {
            Damage(damage);
            return;
        }

        FinalBossActions boss = collision.collider.GetComponent<FinalBossActions>();
        if (boss != null) {
            Die();
            return;
        }
    }

    void Damage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(this.gameObject);
    }
}
