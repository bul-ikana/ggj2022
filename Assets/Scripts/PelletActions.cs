using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PelletActions : MonoBehaviour
{
    // Heal mecha on collision
    void OnTriggerEnter2D(Collider2D collision)
    {
        MechaActions mecha = collision.GetComponent<MechaActions>();

        if (mecha != null)
        {
            mecha.Heal(10);
            Destroy(this.gameObject);
        }
    }
}
