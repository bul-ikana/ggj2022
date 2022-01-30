using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateActions : MonoBehaviour
{
    public int gateNumber;
    public bool active;
    GameManagerScript gameManager;
    public Sprite disabledSprite;

    void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!active || gameManager.mechaAtGate)
        {
            return;
        }

        MechaActions mecha = collision.GetComponent<MechaActions>();

        if (mecha != null) {
            gameManager.mechaAtGate = true;
            gameManager.SetMechaPosition(mecha.transform.position);
            gameManager.ChangeView("Gate" + gateNumber);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (!active || !gameManager.mechaAtGate)
        {
            return;
        }

        MechaActions mecha = collision.GetComponent<MechaActions>();

        if (mecha != null) {
            gameManager.mechaAtGate = false;
        }
    }

    public void DisableGate()
    {
        active = false;
        transform.GetChild(0).GetComponent<Light>().enabled = false;
        GetComponent<SpriteRenderer>().sprite = disabledSprite;
    }
}
