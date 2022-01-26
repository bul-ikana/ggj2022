using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyActions : MonoBehaviour
{
    public int health;
    public int damage;
    public float speed;
    public int pelletDrop;

    GameObject mecha;

    protected virtual void Start()
    {
         mecha = GameObject.Find("Mecha");
    }

    void Update()
    {
        MoveTowardsMecha();
        RotateTowardsMecha();
    }

    // Damage mecha on collision
    void OnCollisionEnter2D(Collision2D collision)
    {
        MechaActions mecha = collision.collider.GetComponent<MechaActions>();

        if (mecha != null)
        {
            mecha.Damage(damage);
            Destroy(this.gameObject);
        }
    }

   protected void MoveTowardsMecha()
    {
        transform.position = Vector3.MoveTowards(transform.position, mecha.transform.position, speed * Time.deltaTime);
    }
    
    void RotateTowardsMecha()
    {
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
