using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletActions : MonoBehaviour
{
    protected const string BULLET_STOP_TAG = "BulletStop";

    public int damage = 24;
    public float speed = 20f;
    public float time = 1f;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
        Destroy(this.gameObject, time);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == BULLET_STOP_TAG) {
            EnemyActions enemy = collision.GetComponent<EnemyActions>();

            if (enemy != null) {
                enemy.Damage(damage);
            }

            Destroy(this.gameObject);
        }
    }
}
