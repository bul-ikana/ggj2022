using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    HealthBarActions hb;
    GameManagerScript gm;

    void Start()
    {
        hb = GameObject.Find("HealthBar").GetComponent<HealthBarActions>();
        gm = GameObject.Find("GameManager").GetComponent<GameManagerScript>();

        InitializeHealth();
        InvokeRepeating("Damage", 0, 1f);
    }

    void InitializeHealth()
    {
        int health = gm.mechaHealth;
        int maxHealth = gm.mechaMaxHealth;

        hb.SetMaxHealth(maxHealth);
        hb.SetHealth(health);
    }

    void Damage()
    {
        gm.mechaHealth -= 2;
        hb.SetHealth(gm.mechaHealth);

        if (gm.mechaHealth <= 0)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        gm.ChangeView("Gameover");
    }
}
