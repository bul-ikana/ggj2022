using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyActions : MonoBehaviour
{
    public int health = 120;

    public void Damage(int damage) {
        health -= damage;
        if (health <= 0) {
            Die();
        }
    }

    void Die()
    {
        Destroy(this.gameObject);
    }
}
