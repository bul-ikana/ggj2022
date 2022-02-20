using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtifactActions : MonoBehaviour
{
    GameManagerScript gameManager;

    void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        MechaActions mecha = collision.GetComponent<MechaActions>();

        if (mecha != null)
        {
            gameManager.ChangeView("Credits");
        }
    }
}
