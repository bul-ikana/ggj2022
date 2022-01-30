using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalGateActions : MonoBehaviour
{
    GameObject gem1;
    GameObject gem2;
    GameObject gem3;
    Upgrades upgrades;
    GameManagerScript gm;

    bool active = false;

    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManagerScript>();

        upgrades = gm.getPlayerUpgrades();
        gem1 = GameObject.Find("Gem1");
        gem2 = GameObject.Find("Gem2");
        gem3 = GameObject.Find("Gem3");

        if (!upgrades.hasBombs)
        {
            gem1.SetActive(false);
        }

        if (!upgrades.hasLaser)
        {
            gem2.SetActive(false);
        }

        if (!upgrades.hasVision)
        {
            gem3.SetActive(false);
        }

        if (
            upgrades.hasBombs &&
            upgrades.hasLaser &&
            upgrades.hasVision
        ) {
            active = true;
            transform.GetChild(3).GetComponent<Light>().enabled = true;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!active || gm.mechaAtGate)
        {
            return;
        }

        MechaActions mecha = collision.GetComponent<MechaActions>();

        if (mecha != null) {
            gm.mechaAtGate = true;
            gm.SetMechaPosition(mecha.transform.position);
            gm.ChangeView("Gate4");
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (!active || !gm.mechaAtGate)
        {
            return;
        }

        MechaActions mecha = collision.GetComponent<MechaActions>();

        if (mecha != null) {
            gm.mechaAtGate = false;
            TriggerFinalBoss();
        }
    }

    void TriggerFinalBoss()
    {
        Instantiate(Resources.Load("FinalBossPrefab"), transform.position, transform.rotation);

        Destroy(this.gameObject);
    }
}
