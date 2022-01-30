using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

using Cinemachine;

public class MechaUI : MonoBehaviour
{
    float shakeTime = 0;

    Image[] bullets;
    MechaActions mecha;
    HealthBarActions hb;
    GameManagerScript gm;
    CinemachineVirtualCamera vcam;
    CinemachineBasicMultiChannelPerlin perlin;

    void Awake()
    {
        vcam = GameObject.Find("Vcam").GetComponent<CinemachineVirtualCamera>();
        perlin = vcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    void Start()
    {
        bullets = new Image[] {
            GameObject.Find("Bullet1").GetComponent<Image>(),
            GameObject.Find("Bullet2").GetComponent<Image>(),
            GameObject.Find("Bullet3").GetComponent<Image>()
        };

        mecha = GameObject.Find("Mecha").GetComponent<MechaActions>();
        hb = GameObject.Find("HealthBar").GetComponent<HealthBarActions>();
        gm = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
    }

    void Update()
    {
        ReduceCameraShake();
    }

    public void InitializeHealth()
    {
        int health = gm.mechaHealth;
        int maxHealth = gm.mechaMaxHealth;

        mecha.SetHealth(health, maxHealth);

        hb.SetMaxHealth(maxHealth);
        hb.SetHealth(health);
    }

    public void UpdateHealth(int health)
    {
        gm.mechaHealth = health;
        hb.SetHealth(health);
    }

    public void UpdateWeapon(int weapon)
    {
        Array.ForEach(bullets, bullet => bullet.enabled = false);
        bullets[weapon].enabled = true;
    }

    public void ShakeCamera(float intensity, float time)
    {
        perlin.m_AmplitudeGain = intensity;
        shakeTime = time;
    }

    public void GameOver()
    {
        gm.ChangeView("Gameover");
    }

    void ReduceCameraShake()
    {
        if (shakeTime > 0)
        {
            shakeTime -= Time.deltaTime;
            if (shakeTime <= 0)
            {
                perlin.m_AmplitudeGain = 0f;
            }
        }
    }
}
