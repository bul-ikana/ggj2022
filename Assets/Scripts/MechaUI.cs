using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MechaUI : MonoBehaviour
{
    Image[] bullets;
    HealthBarActions hb;

    void Start()
    {
        bullets = new Image[] {
            GameObject.Find("Bullet1").GetComponent<Image>(),
            GameObject.Find("Bullet2").GetComponent<Image>(),
            GameObject.Find("Bullet3").GetComponent<Image>()
        };

        hb = GameObject.Find("HealthBar").GetComponent<HealthBarActions>();
    }

    public void InitializeHealth(int health, int maxHealth)
    {
        hb.SetMaxHealth(maxHealth);
        hb.SetHealth(health);
    }

    public void UpdateHealth(int health)
    {
        hb.SetHealth(health);
    }

    public void UpdateWeapon(int weapon)
    {
        Array.ForEach(bullets, bullet => bullet.enabled = false);
        bullets[weapon].enabled = true;
    }
}
