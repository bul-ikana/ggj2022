using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletActions : MonoBehaviour
{
    public int damage = 24;
    public float speed = 20f;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
        Destroy(this.gameObject, 1f);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyActions enemy = collision.GetComponent<EnemyActions>();

        if (enemy != null) {
            enemy.Damage(damage);
        }

        Destroy(this.gameObject);
    }
}
