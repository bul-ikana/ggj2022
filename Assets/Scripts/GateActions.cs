using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateActions : MonoBehaviour
{
    MechaActions mecha;

		public int gateNumber;
    
    void Start()
    {
        mecha = GameObject.Find("Mecha").GetComponent<MechaActions>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        MechaActions mecha = collision.GetComponent<MechaActions>();

        if (mecha != null) {
            mecha.AllowDisembark(gateNumber);
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
