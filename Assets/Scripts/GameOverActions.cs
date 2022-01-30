using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverActions : MonoBehaviour
{
    GameManagerScript gm;

    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManagerScript>();

        gm.mechaHealth =gm.mechaMaxHealth;
    }
}
