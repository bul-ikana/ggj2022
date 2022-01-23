using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateActions : MonoBehaviour
{
    MechaActions mecha;
    
    void Start()
    {
        mecha = GameObject.Find("Mecha").GetComponent<MechaActions>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        MechaActions mecha = collision.GetComponent<MechaActions>();

        if (mecha != null) {
            mecha.AllowDisembark();
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        MechaActions mecha = collision.GetComponent<MechaActions>();

        if (mecha != null) {
            mecha.DenyDisembark();
        }
    }
}
