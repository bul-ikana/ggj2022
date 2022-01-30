using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateActions : MonoBehaviour
{
    public int gateNumber;
    public bool active = true;
    GameManagerScript gameManager;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        MechaActions mecha = collision.GetComponent<MechaActions>();

        if (mecha != null) {
						mecha.gateToEnter = "Gate" + gateNumber;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        MechaActions mecha = collision.GetComponent<MechaActions>();

        if (mecha != null) {
						mecha.gateToEnter = null;
        }
    }
}
