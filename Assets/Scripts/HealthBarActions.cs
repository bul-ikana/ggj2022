using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarActions : MonoBehaviour
{
    Slider slider;
    int maxHealth = 100;

    void Start()
    {
        slider = GetComponent<Slider>();
    }

    public void SetMaxHealth(int health)
    {
        maxHealth = health;
    }

    public void SetHealth(int health)
    {
        slider.value = 1f * health / maxHealth;
        Debug.Log(health);
        Debug.Log(maxHealth);
        Debug.Log(health / maxHealth);
        Debug.Log(slider.value);
    }
}
