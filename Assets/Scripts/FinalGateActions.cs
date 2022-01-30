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
    }
}
