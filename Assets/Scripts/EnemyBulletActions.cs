using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletActions : BulletActions
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == BULLET_STOP_TAG) {
            MechaActions mecha = collision.GetComponent<MechaActions>();

            if (mecha != null) {
                mecha.Damage(damage);
            }

            Destroy(this.gameObject);
        }
    }
}
