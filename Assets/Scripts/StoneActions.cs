using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneActions : MonoBehaviour
{
    public int health;
    public int damage;

    protected SoundManager audio;

    void Start()
    {
        audio = GetComponent<SoundManager>();
    }

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
        } else {
            audio.Play("damage");
        }
    }

    void Die()
    {
        Instantiate(Resources.Load("DestroyedStone"), transform.position, transform.rotation);
        Destroy(this.gameObject);
    }
}
