using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyActions : MonoBehaviour
{
    public int speed = 1;
    public int health = 120;
    public int pelletDrop = 65;

    GameObject mecha;

    void Start()
    {
         mecha = GameObject.Find("Mecha");
    }

    void Update()
    {
        MoveTowardsMecha();
    }

    // Damage mecha on collision
    void OnTriggerEnter2D(Collider2D collision)
    {
        MechaActions mecha = collision.GetComponent<MechaActions>();

        if (mecha != null)
        {
            mecha.Damage(40);
            Destroy(this.gameObject);
        }
    }

    void MoveTowardsMecha()
    {
        // Move
        transform.position = Vector3.MoveTowards(transform.position, mecha.transform.position, speed * Time.deltaTime);

        // Rotate
        Vector3 direction = mecha.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    public void Damage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (Random.Range(1,100) < pelletDrop)
        {
            Instantiate(Resources.Load("PelletPrefab"), transform.position, transform.rotation);
        }

        Destroy(this.gameObject);
    }
}
